using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOptionsButtonsScript : MonoBehaviour
{
    public void Set0()
    {
        DialogueSystemScript.choosen_dialogue_option = 0;
    }

    public void Set1()
    {
        DialogueSystemScript.choosen_dialogue_option = 1;
    }
    public void Set2()
    {
        DialogueSystemScript.choosen_dialogue_option = 2;
    }
    public void Set3()
    {
        DialogueSystemScript.choosen_dialogue_option = 3;
    }
}
