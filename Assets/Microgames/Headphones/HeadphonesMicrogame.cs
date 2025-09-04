using UnityEngine;

public class HeadphonesMicrogame : MicrogameBase
{
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
