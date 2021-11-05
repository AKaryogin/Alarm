using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _body;

    private const string Speed = "Speed";

    private void FixedUpdate() {
        float directionX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float directionY = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        _animator.SetFloat(Speed, Mathf.Abs(directionX) + Mathf.Abs(directionY));

        transform.Translate(directionX, directionY, 0);

        if(directionX > 0) 
            _body.rotation = Quaternion.Euler(0f, 0f, -90f);

        if(directionX < 0) 
            _body.rotation = Quaternion.Euler(0f, 0f, 90f);

        if(directionY > 0) 
            _body.rotation = Quaternion.Euler(0f, 0f, 0f);

        if(directionY < 0) 
            _body.rotation = Quaternion.Euler(0f, 0f, 180f);
    }
}
