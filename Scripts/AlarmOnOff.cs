using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOnOff : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private SetVolume _setVolume;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.TryGetComponent<Player>(out Player player)) 
        {
            _alarm.Play();
            _setVolume.StartSetVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.TryGetComponent<Player>(out Player player)) 
        {
            _alarm.Stop();
            _setVolume.StoptSetVolume();
        }
    }
    
}
