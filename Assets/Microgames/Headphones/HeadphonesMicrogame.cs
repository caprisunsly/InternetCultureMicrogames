using UnityEngine;
using UnityEngine.UI;

public class HeadphonesMicrogame : MicrogameBase
{
    [SerializeField] Image image;
    [SerializeField] Sprite s1, s2;
    bool t;

    private void OnEnable()
    {
        //tunes into the radio station
        MicrogameManager.OnMicrogameStarted += MinigameStart;
        MicrogameManager.OnMicrogameEnded += MinigameEnd;
    }

    private void OnDisable()
    {
        //tunes out of the radio station
        MicrogameManager.OnMicrogameStarted -= MinigameStart;
        MicrogameManager.OnMicrogameEnded -= MinigameEnd;
    }

    void MinigameStart()
    {

    }

    void MinigameEnd()
    {

    }
}
