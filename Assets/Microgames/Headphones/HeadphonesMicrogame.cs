using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadphonesMicrogame : MicrogameBase
{
    [SerializeField] Image image;
    [SerializeField] Slider slider;
    [SerializeField] List<Sprite> babyfaces;
    [SerializeField] List<Sprite> successFaces;

    [SerializeField] float animationSpeed;

    Coroutine c_SuccessSpriteLoop;

    private void Start()
    {
        image.sprite = babyfaces[0];
        slider.maxValue = babyfaces.Count - 1;
    }

    public void ChangeFaceSprite()
    {
        image.sprite = babyfaces[Mathf.RoundToInt(slider.value)];
        if (slider.value == slider.maxValue)
        {
            //disable slider
            slider.enabled = false;
            //broadcast microgamesuccess
            BroadcastGameSuccess();
            //heels lip flaps
            c_SuccessSpriteLoop = StartCoroutine(SuccessSpriteLoop());
            //heels says pronouns
            AudioManager.instance.PlayOneShot(AudioManager.instance.headphones_success, 0.8f);
        }
    }

    private void OnDestroy()
    {
        if (c_SuccessSpriteLoop != null) StopCoroutine(c_SuccessSpriteLoop);
    }

    IEnumerator SuccessSpriteLoop()
    {
        float loopTime = 5;
        int index = 0;
       
        while (loopTime > 0)
        {
            //set sprite to the sprite at position of "index" in the successFaces list
            image.sprite = successFaces[index];
            //reducing loop time so it doesn't run infinitely
            loopTime = loopTime - 1 / animationSpeed;
            //pause loop execution for amount of time based on the set animation speed
            yield return new WaitForSeconds(1 / animationSpeed);
            //increment index by 1
            index = index + 1;
            //check if value of index is higher than the list count, if so reset to start of list
            if (index > successFaces.Count - 1) index = 0;
        }
    }
}
