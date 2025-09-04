using System;
using System.Collections;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    //radio stations
    public static event Action OnMinigameStarted;
    public static event Action OnMinigameEnded;

    //choose a game & store a buffer of selected games
    //load the game scene
    //invoke OnMinigameStarted
    //wait until the game is finished (time runs out)
    //evaluate player success and player loss
    //check remaining health -> if its 0, end game
    //                       -> else choose new game

    IEnumerator MinigameLoop()
    {
        yield return null;
    }
}
