using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    AudioSource audiosource;
    public AudioClip _HoverAC, _SelectAC;

    [SerializeField]
    AudioSource audiosourceVO;
   
    public enum AudioClipType {hoverAC,selectedAC };

    public void PlaySound(AudioClipType clip)
    {
        AudioClip aclip=null;

        if (clip==AudioClipType.hoverAC)
        {
            aclip = _HoverAC;
        }
        else if(clip==AudioClipType.selectedAC)
        {
            aclip = _SelectAC;
        }

        if (!aclip)
            return;
        if(audiosource.isPlaying)
        {
            audiosource.Stop();
            audiosource.clip = aclip;
            audiosource.Play();
        }
        else
        {
            audiosource.clip = aclip;
            audiosource.Play();
        }
    }

    public void PlayVO(Action<bool> callback, AudioClip clip,bool waitForEnd)
    {
        StartCoroutine(WaitForVo(callback,clip,waitForEnd));
    }
    IEnumerator WaitForVo(Action<bool> callback, AudioClip clip, bool waitForEnd)
    {
       
            if (audiosourceVO.isPlaying)
                audiosourceVO.Stop();
            audiosourceVO.clip = clip;
            audiosourceVO.Play();
            if(waitForEnd)
            {
                while (audiosourceVO.isPlaying)
                {
                    yield return null;
                }
                callback(true);
            }
            else
            {
                callback(false);
            }
            
        
        yield return new WaitForEndOfFrame();
    }
}
