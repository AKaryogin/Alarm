using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _offset;
    
    void Update()
    {
        gameObject.transform.position = new Vector3(_player.position.x, _player.position.y + _offset, transform.position.z);
    }
}
