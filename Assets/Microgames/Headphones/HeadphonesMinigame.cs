using UnityEngine;

public class HeadphonesMinigame : MonoBehaviour
{
    private void OnEnable()
    {
        //tunes into the radio station
        MinigameManager.OnMinigameStarted += MinigameStart;
        MinigameManager.OnMinigameEnded += MinigameEnd;
    }

    private void OnDisable()
    {
        //tunes out of the radio station
        MinigameManager.OnMinigameStarted -= MinigameStart;
        MinigameManager.OnMinigameEnded -= MinigameEnd;
    }

    void MinigameStart()
    {

    }

    void MinigameEnd()
    {

    }
}
