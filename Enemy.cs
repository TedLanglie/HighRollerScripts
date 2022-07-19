using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Move Towards")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 4f;
    private Rigidbody _rb;
    [Header ("Effects")]
    [SerializeField] private GameObject _deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.fixedDeltaTime);
        _rb.MovePosition(pos);
        transform.LookAt(_target);
    }

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

    public void changeEnemySpeed(float changeAmount)
    {
        _speed += changeAmount;
        if(_speed < 0) _speed+= (changeAmount*-1 + 1);
    }
}
