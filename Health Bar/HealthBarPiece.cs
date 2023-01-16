using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPiece : MonoBehaviour
{
    public Sprite emptyBar, oneQuarterBar, halfBar, threeQuartersBar, fullBar;
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
            case BarStatus.OneQuarter:
                barImage.sprite = oneQuarterBar;
                break;
            case BarStatus.Half:
                barImage.sprite = halfBar;
                break;
            case BarStatus.ThreeQuarters:
                barImage.sprite = threeQuartersBar;
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
    OneQuarter,
    Half,
    ThreeQuarters,
    Full
}
