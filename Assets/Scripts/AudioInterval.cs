using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioInterval : MonoBehaviour
{
    public AudioSource AS;
    public float interval;// Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        PlayAudio(AS.clip);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void PlayAudio(AudioClip clip, UnityAction callback = null, bool isLoop = false)
    {
        
        AS.clip = clip;
        AS.loop = isLoop;
        AS.Play();
        
        StartCoroutine(AudioPlayFinished(AS.clip.length, callback));
    }
    
    private IEnumerator AudioPlayFinished(float time, UnityAction callback)
    {
        yield return new WaitForSeconds(time+interval);
        PlayAudio(AS.clip);
       
    }
}
