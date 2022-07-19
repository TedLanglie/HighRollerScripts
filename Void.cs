using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    [Header ("Effects")]
    [SerializeField] private GameObject _deathEffect;
    public void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Player":
            Instantiate(_deathEffect, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
            other.gameObject.GetComponent<TedLanglie_PlayerController>().DestroySelf();
            UImanager.instance.DeathEvent();
            break;
        }
    }
}
