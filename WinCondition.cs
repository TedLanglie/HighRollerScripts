using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject _winEffect;
    public void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Player":
            Instantiate(_winEffect, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
            other.gameObject.GetComponent<TedLanglie_PlayerController>().DestroySelf();
            UImanager.instance.WinEvent();
            Debug.Log("PlayerContact");
            break;
        }
    }
}
