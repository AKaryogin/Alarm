using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmActivator : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private VolumeController _volumeController;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.TryGetComponent<Player>(out Player player)) 
        {
            _alarm.Play();
            _volumeController.StartSetVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.TryGetComponent<Player>(out Player player)) 
        {
            _alarm.Stop();
            _volumeController.StoptSetVolume();
        }
    }
    
}
