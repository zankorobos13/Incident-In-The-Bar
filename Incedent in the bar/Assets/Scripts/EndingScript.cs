using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class EndingScript : MonoBehaviour
{
    public GameObject Text;
    public GameObject NextButton;
    public static int i = 0;

    private string[] Ending1 = new string[] { "Tommy motorcycle empties his glass without leaving the bar", "His consciousness blurs, his legs give way and he falls to the floor", "The policeman checks his pulse", "Tommy is dead", "The policeman quickly realized what was going on and arrested you", "At the trial, you try to reduce your punishment by telling who gave you the poison", "But they don't believe you", " You're being sentenced to life in prison for the murder of a Rock'n'Roll legend" };
    private string[] Ending2 = new string[] { "A crazy fan approaches Tommy Motorcycle", "There are a lot of people around him, but none of them are police officers", "The fan pulls out a gun and manages to fire 6 shots before someone from the crowd intervenes", "Tommy dies, and the psychopath is arrested" };
    private string[] Ending3 = new string[] { "The mad fan walks away from the bar", "He walks up to Tommy Motorcycle and pulls out a gun", "His strength leaves him and he falls unconscious", "A policeman runs up to him and handcuffs him", "The fan is taken to the hospital, but he does not survive", "Doctors determine the cause of death - alcohol intoxication", "Tommy Motorcycle is alive, thanks to you" };
    private string[] Ending4 = new string[] { "You are arrested and the interrogation begins", "During the interrogation, you tell me who gave you the poison", "You're both going to jail, you're going to be jailed for 6 years, and your accomplice is going to be jailed for 8 years" };
    private string[] Ending5 = new string[] { "Tommy the Motorcyclist's girlfriend was arrested", "During the interrogation, she confessed everything", "She was sent to prison for 14 years, and Tommy is still alive, thanks to you" };

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        Text.GetComponent<TextMeshProUGUI>().text = GameControllerScript.Ending.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControllerScript.Ending == 1)
        {
            PlayButtonScript.isUnolcked1 = true;
            if (i < Ending1.Length - 1)
                Text.GetComponent<TextMeshProUGUI>().text = Ending1[i];
            else if (i == Ending1.Length - 1)
            {
                NextButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Main menu";
                Text.GetComponent<TextMeshProUGUI>().text = Ending1[i];
            }
            else
                SceneManager.LoadScene("Menu");
        }
        else if (GameControllerScript.Ending == 2)
        {
            PlayButtonScript.isUnolcked2 = true;
            if (i < Ending2.Length - 1)
                Text.GetComponent<TextMeshProUGUI>().text = Ending2[i];
            else if (i == Ending2.Length - 1)
            {
                NextButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Main menu";
                Text.GetComponent<TextMeshProUGUI>().text = Ending2[i];
            }
            else
                SceneManager.LoadScene("Menu");
        }
        else if (GameControllerScript.Ending == 3)
        {
            PlayButtonScript.isUnolcked3 = true;
            if (i < Ending3.Length - 1)
                Text.GetComponent<TextMeshProUGUI>().text = Ending3[i];
            else if (i == Ending3.Length - 1)
            {
                NextButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Main menu";
                Text.GetComponent<TextMeshProUGUI>().text = Ending3[i];
            }
            else
                SceneManager.LoadScene("Menu");
        }
        else if (GameControllerScript.Ending == 4)
        {
            PlayButtonScript.isUnolcked4 = true;
            if (i < Ending4.Length - 1)
                Text.GetComponent<TextMeshProUGUI>().text = Ending4[i];
            else if (i == Ending4.Length - 1)
            {
                NextButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Main menu";
                Text.GetComponent<TextMeshProUGUI>().text = Ending4[i];
            }
            else
                SceneManager.LoadScene("Menu");
        }
        else if (GameControllerScript.Ending == 5)
        {
            PlayButtonScript.isUnolcked5 = true;
            if (i < Ending5.Length - 1)
                Text.GetComponent<TextMeshProUGUI>().text = Ending5[i];
            else if (i == Ending5.Length - 1)
            {
                NextButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Main menu";
                Text.GetComponent<TextMeshProUGUI>().text = Ending5[i];
            }
            else
                SceneManager.LoadScene("Menu");
        }
    }

    public static void OnClick()
    {
        i++;
    }
}
