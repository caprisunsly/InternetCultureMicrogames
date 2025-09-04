using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] List<SO_Microgame> m_MicrogameMasterList = new();
    List<SO_Microgame> m_MicrogameCurrentList = new();

    //radio stations
    public static event Action OnMinigameStarted;
    public static event Action OnMinigameEnded;

    //choose a game from current list. if empty, pull from master list
    //pick a random index from current list

    //load the game scene
    //invoke OnMinigameStarted
    //wait until the game is finished (time runs out)
    //evaluate player success and player loss
    //check remaining health -> if its 0, end game
    //                       -> else choose new game

    IEnumerator MinigameLoop()
    {
        if (m_MicrogameCurrentList.Count <= 0) m_MicrogameCurrentList = new List<SO_Microgame>(m_MicrogameMasterList);
        int index = UnityEngine.Random.Range(0, m_MicrogameCurrentList.Count - 1);
        SO_Microgame selectedMicrogame = m_MicrogameCurrentList[index];
        //load scene
        yield return null;
    }
}
