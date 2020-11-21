using UnityEngine;
using UnityEngine.Audio;

public class CoinRetrieval : MonoBehaviour
{
    private AudioSource audio_source;

    void Start()
    {
        audio_source = GetComponent<AudioSource>();
    }

    private void OnDestroy() {
        audio_source.Play();        
    }
}
