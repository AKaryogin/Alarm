using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private string _triggerName = "Opening";

    private void OnCollisionEnter2D(Collision2D collision) {        
        if(collision.collider.TryGetComponent<Player>(out Player player))
            _animator.SetTrigger(_triggerName);
    }
}
