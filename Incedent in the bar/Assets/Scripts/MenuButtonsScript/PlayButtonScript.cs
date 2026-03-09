using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    public static bool isUnolcked1 = false;
    public static bool isUnolcked2 = false;
    public static bool isUnolcked3 = false;
    public static bool isUnolcked4 = false;
    public static bool isUnolcked5 = false;

    public GameObject Ending1;
    public GameObject Ending2;
    public GameObject Ending3;
    public GameObject Ending4;
    public GameObject Ending5;

    public GameObject Locker1;
    public GameObject Locker2;
    public GameObject Locker3;
    public GameObject Locker4;
    public GameObject Locker5;

    public GameObject Screen;

    private bool isOnEndingScreen = false;

    private void Update()
    {
        Screen.SetActive(isOnEndingScreen);

        if (isOnEndingScreen)
        {
            Ending1.SetActive(isUnolcked1);
            Ending2.SetActive(isUnolcked2);
            Ending3.SetActive(isUnolcked3);
            Ending4.SetActive(isUnolcked4);
            Ending5.SetActive(isUnolcked5);

            Locker1.SetActive(!isUnolcked1);
            Locker2.SetActive(!isUnolcked2);
            Locker3.SetActive(!isUnolcked3);
            Locker4.SetActive(!isUnolcked4);
            Locker5.SetActive(!isUnolcked5);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Endings()
    {
        isOnEndingScreen = true;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ExitEndings()
    {
        isOnEndingScreen = false;
    }
}
