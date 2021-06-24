using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    public float speed;
    public bool hasTurned;
    [SerializeField]
    private float ZAxisAdd;
    public float fallTime;

    [Header("Ground Detection")]
    public bool groundDetected;
    [SerializeField] Transform groundPos;
    public float groundCheckSize;
    [SerializeField]
    public LayerMask whatIsGround;

    [Header("Wall Detection")]
    public bool wallDetected;
    [SerializeField] Transform wallPos;
    public float wallCheckSize;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Environment();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Environment()
    {
        groundDetected = Physics2D.Raycast(groundPos.position, -transform.up, groundCheckSize, whatIsGround);
        wallDetected = Physics2D.Raycast(wallPos.position, transform.right, wallCheckSize, whatIsGround);

        //Deteccion de Suelo
        if (!groundDetected)
        {
            if (hasTurned == false)
            {
                ZAxisAdd -= 90;
                transform.eulerAngles = new Vector3(0, 0, ZAxisAdd);
                hasTurned = true;
            }

            fallTime -= Time.deltaTime;
        }

        if (groundDetected)
        {
            hasTurned = false;

            fallTime = 1;
        }

        //Deteccion de Pared
        if (wallDetected)
        {
            if (!hasTurned)
            {
                ZAxisAdd += 90;
                transform.eulerAngles = new Vector3(0, 0, ZAxisAdd);
            }
        }

        //Seccion del Antibugs
        if (fallTime == 1)
        {
            rb.gravityScale = 0;
            speed = 3;
        }
        else if (fallTime <= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            ZAxisAdd = 0;
            rb.gravityScale = 50;
            speed = 0;
        }

        //Controlador de direccion
        if (ZAxisAdd <= -360)
        {
            ZAxisAdd = 0;
        }
    }

    void Movement()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundPos.position, new Vector2(groundPos.position.x, groundPos.position.y - groundCheckSize));
        Gizmos.DrawLine(wallPos.position, new Vector2(wallPos.position.x + wallCheckSize, wallPos.position.y));
    }
}
