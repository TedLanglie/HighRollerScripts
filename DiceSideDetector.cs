using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideDetector : MonoBehaviour
{
    [SerializeField] private int _sideOfDice; // should be side ACROSS real side

    public void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Ground":
            UImanager.instance.ChangeSide(_sideOfDice);
            break;
        }
    }
}
