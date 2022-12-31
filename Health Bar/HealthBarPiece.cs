using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPiece : MonoBehaviour
{
    public Sprite emptyBar, oneQuartBar, halfBar, threeQuartsBar, fullBar;
    Image barImage;

    private void Awake()
    {
        barImage = GetComponent<Image>();
    }

    public void SetBarImage(BarStatus status)
    {
        switch (status)
        {
            case BarStatus.Empty:
                barImage.sprite = emptyBar;
                break;
            case BarStatus.OneQuart:
                barImage.sprite = oneQuartBar;
                break;
            case BarStatus.Half:
                barImage.sprite = halfBar;
                break;
            case BarStatus.ThreeQuarts:
                barImage.sprite = threeQuartsBar;
                break;
            case BarStatus.Full:
                barImage.sprite = fullBar;
                break;
        }
    }
}

public enum BarStatus
{
    Empty,
    OneQuart,
    Half,
    ThreeQuarts,
    Full
}
