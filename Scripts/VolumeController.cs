using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolumeController : MonoBehaviour
{
    [SerializeField] private float _durationSetVolume;

    private AudioSource _alarm;
    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _alarm = GetComponent<AudioSource>();
    }

    public void StartSetVolume()
    {
        _currentCoroutine = StartCoroutine(SetVolumeUp(_durationSetVolume));
    }

    public void StoptSetVolume()
    {
        StopCoroutine(_currentCoroutine);
        _alarm.volume = 0;
    }

    private IEnumerator SetVolumeUp(float duration)
    {
        for(int i = 0; i <= duration; i++)
        {
            _alarm.volume += 1 / duration;
            yield return null;
        }
        Debug.Log("Max = " + _alarm.volume);
        _currentCoroutine = StartCoroutine(SetVolumeDown(duration));
    }

    private IEnumerator SetVolumeDown(float duration)
    {
        for(int i = 0; i <= duration; i++)
        {
            _alarm.volume -= 1 / duration;
            yield return null;
        }
        Debug.Log("Min = " + _alarm.volume);
        _currentCoroutine = StartCoroutine(SetVolumeUp(duration));
    }
}
