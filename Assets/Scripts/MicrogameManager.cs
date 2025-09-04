using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicrogameManager : MonoBehaviour
{
    [SerializeField] List<SO_Microgame> m_MicrogameMasterList = new();
    List<SO_Microgame> m_MicrogameCurrentList = new();

    //radio stations
    public static event Action OnMicrogameStarted;
    public static event Action OnMicrogameEnded;

    bool isLoaded = false;
    bool success = false;
    float timeScaleMultiplier = 1;
    [SerializeField] float timeBetweenGames = 4;
    [SerializeField] float timeScaleReduction = .1f;
    [SerializeField] int gamesBetweenSpeedUp = 5;
    [SerializeField] int maxHealth = 4;
    int currentHealth;
    int minigamesCompleted;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        MicrogameBase.MicrogameSuccess += MicrogameSuccess;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        MicrogameBase.MicrogameSuccess -= MicrogameSuccess;
    }

    //choose a game from current list. if empty, pull from master list
    //pick a random index from current list
    //remove from current list

    //load the game scene
    //invoke OnMinigameStarted
    //wait until the game is finished (time runs out)
    //evaluate player success and player loss
    //check remaining health -> if its 0, end game
    //                       -> else choose new game

    IEnumerator MinigameLoop()
    {
        currentHealth = maxHealth;
        minigamesCompleted = 0;
        while (currentHealth > 0)
        {
            if (m_MicrogameCurrentList.Count <= 0) m_MicrogameCurrentList = new List<SO_Microgame>(m_MicrogameMasterList);
            int index = UnityEngine.Random.Range(0, m_MicrogameCurrentList.Count - 1);
            SO_Microgame selectedMicrogame = m_MicrogameCurrentList[index];
            m_MicrogameCurrentList.RemoveAt(index);

            SceneManager.LoadSceneAsync(selectedMicrogame.sceneName, LoadSceneMode.Additive);
            yield return new WaitUntil(() => isLoaded);
            isLoaded = false;

            //play transition animation
            //show the gamePrompt

            OnMicrogameStarted.Invoke();
            yield return new WaitForSeconds(selectedMicrogame.baseTimeLimit * timeScaleMultiplier);
            OnMicrogameEnded.Invoke();

            //play transition out animation
            //unload the scene'
            SceneManager.UnloadSceneAsync(selectedMicrogame.sceneName);

            //evaluate microgame results
            if (success == true)
            {
                //do success stuff
                success = false;
            }
            else
            {
                currentHealth = currentHealth - 1;
                //do failure stuff
            }
            //play animations on the screen between microgames
            yield return new WaitForSeconds(timeBetweenGames);
            //every X games played, reduce the time scale multiplier
        }
        //do stuff after you lose
        //high score, etc
    }

    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isLoaded = true;
    }

    void MicrogameSuccess()
    {
        success = true;
    }
}
