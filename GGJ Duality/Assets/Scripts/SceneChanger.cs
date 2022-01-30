using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private float timer;
    private bool isFadingIn;
    private bool isFadingOut;
    [SerializeField] Image screenFade;
    [SerializeField] int sceneNumber;

    private void Start()
    {
        timer = 0f;
        isFadingIn = true;
        isFadingOut = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (isFadingIn)
        {
            fadeIn();
        }

        if(isFadingOut)
        {
            fadeOut();
        }
    }

    public void ChangeScene(int _sceneNumber)
    {
        timer = 0f;
        isFadingOut = true;
        sceneNumber = _sceneNumber;
    }

    private void fadeIn()
    {
        if (timer >= 1.5f)
        {
            //screenFade.color = new Color(0, 0, 0, 0);
            isFadingIn = false;
        }
        else if (timer >= 1.35f)
        {
            screenFade.color = new Color(0, 0, 0, 0f);
        }
        else if (timer >= 1.2f)
        {
            screenFade.color = new Color(0, 0, 0, 0.1f);
        }
        else if (timer >= 1.05f)
        {
            screenFade.color = new Color(0, 0, 0, 0.2f);
        }
        else if (timer >= 0.9f)
        {
            screenFade.color = new Color(0, 0, 0, 0.3f);
        }
        else if (timer >= 0.75f)
        {
            screenFade.color = new Color(0, 0, 0, 0.4f);
        }
        else if (timer >= 0.6f)
        {
            screenFade.color = new Color(0, 0, 0, 0.5f);
        }
        else if (timer >= 0.45f)
        {
            screenFade.color = new Color(0, 0, 0, 0.6f);
        }
        else if (timer >= 0.3f)
        {
            screenFade.color = new Color(0, 0, 0, 0.7f);
        }
        else if (timer >= 0.15f)
        {
            screenFade.color = new Color(0, 0, 0, 0.8f);
        }
        else if (timer >= 0)
        {
            screenFade.color = new Color(0, 0, 0, 0.9f);
        }
    }

    private void fadeOut()
    {
        if (timer >= 2f)
        {
            isFadingOut = false;
            SceneManager.LoadScene(sceneNumber);
        }
        else if (timer >= 1.35f)
        {
            screenFade.color = new Color(0, 0, 0, 1f);
        }
        else if (timer >= 1.2f)
        {
            screenFade.color = new Color(0, 0, 0, 0.9f);
        }
        else if (timer >= 1.05f)
        {
            screenFade.color = new Color(0, 0, 0, 0.8f);
        }
        else if (timer >= 0.9f)
        {
            screenFade.color = new Color(0, 0, 0, 0.7f);
        }
        else if (timer >= 0.75f)
        {
            screenFade.color = new Color(0, 0, 0, 0.6f);
        }
        else if (timer >= 0.6f)
        {
            screenFade.color = new Color(0, 0, 0, 0.5f);
        }
        else if (timer >= 0.45f)
        {
            screenFade.color = new Color(0, 0, 0, 0.4f);
        }
        else if (timer >= 0.3f)
        {
            screenFade.color = new Color(0, 0, 0, 0.3f);
        }
        else if (timer >= 0.15f)
        {
            screenFade.color = new Color(0, 0, 0, 0.2f);
        }
        else if (timer >= 0)
        {
            screenFade.color = new Color(0, 0, 0, 0.1f);
        }
    }
}
