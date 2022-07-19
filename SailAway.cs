using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailAway : MonoBehaviour
{
    private Rigidbody _rb;
    [Header ("Move Towards")]
    [SerializeField] private Transform _target;
    private bool _sailing = false;
	
	void Start () {
	
		_rb = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate ()
	{
        if(_sailing == true)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, _target.position, 4 * Time.fixedDeltaTime);
            _rb.MovePosition(pos);
        }
	}

    public void SetSail()
    {
        _sailing = true;
    }
}
