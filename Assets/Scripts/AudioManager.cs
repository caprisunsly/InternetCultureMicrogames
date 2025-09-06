using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    //audio source
    [SerializeField] AudioSource oneShotSource;

    //subtitle for inspector window
    [Header("Headphones Microgame")]
    //audio clips
    public AudioClip headphones_success;
    public AudioClip headphones_fail;

    private void Start()
    {
        //singleton pattern. makes it easier to get this component as a variable
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void PlayOneShot(AudioClip clip, float volumeScale = 1f, float pitch = 1f)
    {
        //set the pitch of the audio source
        oneShotSource.pitch = pitch;
        //tell the audio source to play the selected clip, using the selected volume scale
        oneShotSource.PlayOneShot(clip, volumeScale);
    }
}
