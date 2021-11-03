using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInside : MonoBehaviour
{
    [SerializeField] private AudioSource _siren;
    [SerializeField] private float _durationSetVolume;

    private Coroutine _currentCoroutine;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.TryGetComponent<Player>(out Player player)) {
            _siren.Play();
            _currentCoroutine = StartCoroutine(SetVolumeUp(_durationSetVolume));            
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.TryGetComponent<Player>(out Player player)) {
            _siren.Stop();
            _siren.volume = 0;

            StopCoroutine(_currentCoroutine);            
        }
    }

    private IEnumerator SetVolumeUp(float duration) {        

        for(int i = 0; i < duration; i++) {
            _siren.volume += 1 / duration;            
            yield return null;
        }        
        _currentCoroutine = StartCoroutine(SetVolumeDown(duration));
    }

    private IEnumerator SetVolumeDown(float duration) {

        for(int i = 0; i < duration; i++) {
            _siren.volume -= 1 / duration;           
            yield return null;
        }        
        _currentCoroutine = StartCoroutine(SetVolumeUp(duration));
    }
}
