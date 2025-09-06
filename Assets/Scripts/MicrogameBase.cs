using System;
using UnityEngine;

public class MicrogameBase : MonoBehaviour
{
    public static event Action MicrogameSuccess;

    protected void BroadcastGameSuccess()
    {
        MicrogameSuccess.Invoke();
    }
    

    private void OnEnable()
    {
        //tunes into the radio station
        MicrogameManager.OnMicrogameStarted += MicrogameStart;
        MicrogameManager.OnMicrogameEnded += MicrogameEnd;
    }

    private void OnDisable()
    {
        //tunes out of the radio station
        MicrogameManager.OnMicrogameStarted -= MicrogameStart;
        MicrogameManager.OnMicrogameEnded -= MicrogameEnd;
    }

    void MicrogameStart()
    {

    }



    void MicrogameEnd()
    {

    }
}


