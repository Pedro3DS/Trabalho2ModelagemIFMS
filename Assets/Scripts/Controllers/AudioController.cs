using UnityEngine;

public class AudioController : MonoBehaviour
{   
    public static AudioController Instance = null;

    [Header("Sources")]
    [SerializeField] private AudioSource GlobalSFX;
    [SerializeField] private AudioSource PlayerSFX;

    [Header("Audios")]
    [SerializeField] private AudioClip CollectClip;
    [SerializeField] private AudioClip JumpClip;
    [SerializeField] private AudioClip TouchGroundClip;

    void Awake()
    {
        if(Instance) Destroy(Instance);
        else Instance = this;
    }

    public void PlayAudio(AudioClip clip, AudioSource source)
    {
        // source.clip = clip;
        source.PlayOneShot(clip);
    }

    public void CollectAudio()
    {
        PlayAudio(CollectClip, GlobalSFX);
    }
    public void JumpAudio()
    {
        PlayAudio(JumpClip, PlayerSFX);
    }
    public void TouchGroundAudio()
    {
        PlayAudio(TouchGroundClip, PlayerSFX);
    }


}
