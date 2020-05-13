using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // // When the user presses PlayButton
    public void PlayButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public GameObject blue, green, red;

    private void Start ()
    {
        Time.timeScale = 1;
        blue.SetActive(true);
        GameManager.instance.SetSelectedBird(0);
        Debug.Log("Selected Menu " + GameManager.instance.GetSelectedBird());
    }

    // Change for Bird
    public void SwitchBird()
    {
        if (GameManager.instance.GetSelectedBird() == 0)
        {
            blue.SetActive(false);
            green.SetActive(true);
            red.SetActive(false);
            GameManager.instance.SetSelectedBird(1);
            Debug.Log("Selected Menu " + GameManager.instance.GetSelectedBird());
        }
        else if (GameManager.instance.GetSelectedBird() == 1)
        {
            blue.SetActive(false);
            green.SetActive(false);
            red.SetActive(true);
            GameManager.instance.SetSelectedBird(2);
            Debug.Log("Selected Menu " + GameManager.instance.GetSelectedBird());
        }
        else if (GameManager.instance.GetSelectedBird() == 2)
        {
            blue.SetActive(true);
            green.SetActive(false);
            red.SetActive(false);
            GameManager.instance.SetSelectedBird(0);
            Debug.Log("Selected Menu " + GameManager.instance.GetSelectedBird());
        }

    }
}
