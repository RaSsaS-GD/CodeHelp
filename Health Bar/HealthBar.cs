using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject barPrefab;
    public Stats stats;

    List<HealthBarPiece> barPieces = new List<HealthBarPiece>();

    private void Start()
    {
        DrawBar();
    }

    private void OnEnable()
    {
        stats.OnPlayerIncreaseHealth += DrawBar;
        stats.OnPlayerDecreaseHealth += DrawBar;
    }

    private void OnDisable()
    {
        stats.OnPlayerIncreaseHealth -= DrawBar;
        stats.OnPlayerDecreaseHealth -= DrawBar;
    }

    public void DrawBar()
    {
        ClearBar();

        float maxHealthRemainder = stats.maxHealth % 4;
        int barsToMake = (int)(stats.maxHealth / 4 + maxHealthRemainder);

        for (int i = 0; i < barsToMake; i++)
        {
            CreateEmptyBar();
        }

        for (int i = 0; i < barPieces.Count; i++)
        {
            int healthStatusRemainder = Mathf.Clamp(stats.currentHealth - (i * 4), 0, 4);
            barPieces[i].SetBarImage((BarStatus)healthStatusRemainder);
        }
    }

    public void CreateEmptyBar()
    {
        GameObject newBar = Instantiate(barPrefab);
        newBar.transform.SetParent(transform);
        newBar.transform.localScale = new Vector3(1, 1, 1);

        HealthBarPiece healthBarComponent = newBar.GetComponent<HealthBarPiece>();
        healthBarComponent.SetBarImage(BarStatus.Empty);
        barPieces.Add(healthBarComponent);
    }

    public void ClearBar()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        barPieces = new List<HealthBarPiece>();
    }
}
