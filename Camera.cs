using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform _playerTransform;

    private Vector3 _cameraOffset;

    [SerializeField] private float _smoothFactor;
    private bool _cameraLock = false;
    // Start is called before the first frame update
    void Start()
    {
        _cameraLock = false;
        _cameraOffset = transform.position - _playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(_cameraLock == false)
        {
            Vector3 newPos = _playerTransform.position + _cameraOffset;

            transform.position = Vector3.Slerp(transform.position, newPos, _smoothFactor);
        }
    }

    public void toggleLockOn()
    {
        _cameraLock = true;
    }
}
