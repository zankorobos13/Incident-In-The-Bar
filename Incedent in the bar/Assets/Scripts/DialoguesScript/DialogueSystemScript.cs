using TMPro;
using UnityEngine;

public class DialogueSystemScript : MonoBehaviour
{
    public GameObject DialogueWindow;
    public GameObject HumanSpawner;

    public static int choosen_dialogue_option = -1;

    public static GameObject current_human;

    private bool isPoisonAlreadyTriggered;
    public class Dialogue
    {
        public static Dialogue[] dialogues = new Dialogue[13];
        private DialogueNode start;
        public Dialogue(DialogueNode start)
        {
            this.start = start;
        }

        public void Next(int dialogue_option)
        {
            if (start.GetNextDialogueNodes() != null)
                start = start.GetNextDialogueNodes()[dialogue_option];
            else
                start = null;
            
        }

        public DialogueNode GetCurrentNode()
        {
            return start;
        }

        


    }

    public class DialogueNode
    {
        private string replica;
        private string[] dialogue_options;
        private DialogueNode[] next_dialogue_nodes;

        public DialogueNode(string replica, string[] dialogue_options, DialogueNode[] next_dialogue_nodes)
        {
            this.replica = replica;
            this.dialogue_options = dialogue_options;
            this.next_dialogue_nodes = next_dialogue_nodes;
        }

        public string GetReplica()
        {
            return replica;
        }

        public string[] GetDialogueOptions()
        {
            return dialogue_options;
        }

        public DialogueNode[] GetNextDialogueNodes()
        {
            return next_dialogue_nodes;
        }

        public void SetNextDialogueNode(DialogueNode[] next_dialogue_nodes)
        {
            this.next_dialogue_nodes = next_dialogue_nodes;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        DialogueWindow.SetActive(false);
        choosen_dialogue_option = -1;
        isPoisonAlreadyTriggered = false;
        // D1
        DialogueNode D1_Node1 = new DialogueNode("Hi Joe, I have great news for you! A lot of people are coming to our bar today, some famous rocker was holding a concert nearby and he already paid for all the drinks for this evening, so pour everyone for free. I know it's your first day, so let me quickly remind you what to do.", new string[] { "Next." }, null);
        DialogueNode D1_Node2 = new DialogueNode("To make a cocktail, use a shaker, everything you need is on the shelves below, also I fixed the recipes on the wall. Make me a Daiquiri for coaching. When it's ready - Drag&Drop it to me.", null, null);
        DialogueNode D1_Node3 = new DialogueNode("Thanks Joe! I'm going to meet the customers.", new string[] { "Next." }, null);

        D1_Node1.SetNextDialogueNode(new DialogueNode[] { D1_Node2 });
        D1_Node2.SetNextDialogueNode(new DialogueNode[] { D1_Node3 });

        Dialogue dialogue1 = new Dialogue(D1_Node1);

        Dialogue.dialogues[0] = dialogue1;
        //
        // D2
        DialogueNode D2_Node1 = new DialogueNode("Oh, I'm sorry, could you pour me another glass of Wine, because I'm too nervous. To do this, simply put one Wine in a shaker.", null, null);
        DialogueNode D2_Node2 = new DialogueNode("Well done! Have a good job!", new string[] { "Next." }, null);

        D2_Node1.SetNextDialogueNode(new DialogueNode[] { D2_Node2 });

        Dialogue dialogue2 = new Dialogue(D2_Node1);

        Dialogue.dialogues[1] = dialogue2;
        //
        // D3
        DialogueNode D3_Node1 = new DialogueNode("The Tommy Motorcycle concert was very good, have you heard anything about him?", new string[] { "Yes, i'm a huge fan!", "No." }, null);

        DialogueNode D3_Node21 = new DialogueNode("You're cool. What's your favorite song?", new string[] { "Highway to Moto", "Where is my Moto?", "Still Moto", "Enjoy the Moto" }, null);
        DialogueNode D3_Node22 = new DialogueNode("Be sure to listen after work, he's a living legend, \"Still Moto\" is a very good song. Pour me a Screwdriver, please.", null, null);

        DialogueNode D3_Node21_124 = new DialogueNode("Em... You could have just said you hadn't heard of him. Pour the Screwdriver.", null, null);
        DialogueNode D3_Node21_3 = new DialogueNode("Oh, I love this song, you are real fan! Pour me a Screwdriver please.", null, null);

        DialogueNode D3_Node221 = new DialogueNode("Thank you!", new string[] { "Next." }, null);

        D3_Node1.SetNextDialogueNode(new DialogueNode[] { D3_Node21, D3_Node22 });
        D3_Node21.SetNextDialogueNode(new DialogueNode[] { D3_Node21_124, D3_Node21_124, D3_Node21_3, D3_Node21_124 });
        D3_Node22.SetNextDialogueNode(new DialogueNode[] { D3_Node221 });

        Dialogue dialogue3 = new Dialogue(D3_Node1);

        Dialogue.dialogues[2] = dialogue3;
        // D4
        DialogueNode D4_Node1 = new DialogueNode("The ticket prices for this concert were huge. Thank God the bar is free. It seems to me that Tommy earns millions of dollars from each such concert.", new string[] { "Next." }, null);
        DialogueNode D4_Node2 = new DialogueNode("Uh, sorry, I'm talking too much. Please give me a Rum Punch.", null, null);
        DialogueNode D4_Node3 = new DialogueNode("Thanks for free drinks, bro!", new string[] { "Next." }, null);

        D4_Node1.SetNextDialogueNode(new DialogueNode[] { D4_Node2 });
        D4_Node2.SetNextDialogueNode(new DialogueNode[] { D4_Node3 });

        Dialogue dialogue4 = new Dialogue(D4_Node1);

        Dialogue.dialogues[3] = dialogue4;
        //
        // D5

        DialogueNode D5_Node1 = new DialogueNode("Hey buddy. I'm keeping order here, everything seems to be fine for now, but you know, bar, celebrities... Just tell me if you see anything strange, okay?", new string[] { "Of course, Mr. Officer!", "*Keep silence*" }, null);
        DialogueNode D5_Node21 = new DialogueNode("Okay then.", new string[] { "Next." }, null);
        DialogueNode D5_Node22 = new DialogueNode("*The cop is silently staring at you*", new string[] { "Next." }, null);
        DialogueNode D5_Node3 = new DialogueNode("It's a little boring here, pour me a Vodka Sour.", null, null);
        DialogueNode D5_Node4 = new DialogueNode("Thank you.", new string[] { "Next." }, null);


        D5_Node1.SetNextDialogueNode(new DialogueNode[] { D5_Node21, D5_Node22 });
        D5_Node21.SetNextDialogueNode(new DialogueNode[] { D5_Node3 });
        D5_Node22.SetNextDialogueNode(new DialogueNode[] { D5_Node21 });
        D5_Node3.SetNextDialogueNode(new DialogueNode[] { D5_Node4 });

        Dialogue dialogue5 = new Dialogue(D5_Node1);

        Dialogue.dialogues[4] = dialogue5;
        //
        // D6

        DialogueNode D6_Node1 = new DialogueNode("Ah, the cops at my party, what nonsense! HEY YOU, pour Vodka for the KING OF ROCK!", null, null);
        DialogueNode D6_Node2 = new DialogueNode("Oh, finally, what took you so long?", new string[] { "I'm sorry.", "*Keep silence*" }, null);
        DialogueNode D6_Node31 = new DialogueNode("Oh, SHUT UP and keep working!", new string[] { "Next." }, null);
        DialogueNode D6_Node32 = new DialogueNode("Oh my God you're just useless!", new string[] { "Next." }, null);

        D6_Node1.SetNextDialogueNode(new DialogueNode[] { D6_Node2 });
        D6_Node2.SetNextDialogueNode(new DialogueNode[] { D6_Node31, D6_Node32 });

        Dialogue dialogue6 = new Dialogue(D6_Node1);

        Dialogue.dialogues[5] = dialogue6;
        //
        // D7

        DialogueNode D7_Node1 = new DialogueNode("Oh, these celebrities, right? But he wasn't like that at the beginning of his career.", new string[] { "Yeah.", "It's okay." }, null);
        DialogueNode D7_Node2 = new DialogueNode("Don't be offended by him, he's very drunk.", new string[] { "Next." }, null);
        DialogueNode D7_Node3 = new DialogueNode("My friend recommended that I take Rum Sunset. I want to try.", null, null);

        D7_Node1.SetNextDialogueNode(new DialogueNode[] { D7_Node2, D7_Node2 });
        D7_Node2.SetNextDialogueNode(new DialogueNode[] { D7_Node3 });

        Dialogue dialogue7 = new Dialogue(D7_Node1);

        Dialogue.dialogues[6] = dialogue7;
        //
        // D8

        DialogueNode D8_Node1 = new DialogueNode("Hey handsome!", new string[] { "Heey, would you like to order something?" }, null);
        DialogueNode D8_Node2 = new DialogueNode("Yes! But... first... I need your help.", new string[] { "What is the problem?" }, null);
        DialogueNode D8_Node3 = new DialogueNode("Listen, i see you are a smart guy. I will give you something. It.. It is a poison. Mix it with Vodka and give it to Tommy. But don't try to mix it with other drinks it will not work Ha-Ha!", new string[] { "It is a POISON?????", "*Take it*" }, null);
        DialogueNode D8_Node41 = new DialogueNode("Look, Tommy is just terrible. Do you remember how he talked to you? And I'm his girlfriend. I have to deal with him every single day. It's a living hell.", new string[] { "Why don't you just break up with him?", "I won't do it.", "Give it to me." }, null);
        DialogueNode D8_Node42 = new DialogueNode("I knew you are a good guy. Mix it with Vodka and give it to Tommy, but there are a lot of cops here, be careful. And now, please, give me a White Russian.", null, null);
        DialogueNode D8_Node51 = new DialogueNode("I can't, he just won't let me go. Please, help me!", new string[] { "I won't do it.", "Fine. Give it to me." }, null);
        DialogueNode D8_Node52 = new DialogueNode("I'll just leave it here. Think about it, mix it with Vodka and give it to Tommy. Now, please, give me a White Russian.", null, null);
        DialogueNode D8_Node53 = new DialogueNode("Thank you SO MUCH! Mix it with Vodka and give it to Tommy. Now, please, give me a White Russian.", null, null);

        D8_Node1.SetNextDialogueNode(new DialogueNode[] { D8_Node2 });
        D8_Node2.SetNextDialogueNode(new DialogueNode[] { D8_Node3 });
        D8_Node3.SetNextDialogueNode(new DialogueNode[] { D8_Node41, D8_Node42 });
        D8_Node41.SetNextDialogueNode(new DialogueNode[] { D8_Node51, D8_Node52, D8_Node53 });
        D8_Node51.SetNextDialogueNode(new DialogueNode[] { D8_Node52, D8_Node53 });

        Dialogue dialogue8 = new Dialogue(D8_Node1);

        Dialogue.dialogues[7] = dialogue8;
        //
        // D9

        DialogueNode D9_Node1 = new DialogueNode("Good evening. Mulled wine, please.", null, null);
        DialogueNode D9_Node2 = new DialogueNode("Thank you.", new string[] {"Next." }, null);

        D9_Node1.SetNextDialogueNode(new DialogueNode[] { D9_Node2 });

        Dialogue dialogue9 = new Dialogue(D9_Node1);
        Dialogue.dialogues[8] = dialogue9;
        //
        // D10
        DialogueNode D10_Node1 = new DialogueNode("YOU! VODKA! NOW!", null, null);

        Dialogue dialogue10 = new Dialogue(D10_Node1);
        Dialogue.dialogues[9] = dialogue10;
        //
        // D11
        DialogueNode D11_Node1 = new DialogueNode("How's it going, kid, did you see anything strange?", new string[] { "TOMMY'S GIRLFRIEND WANT KILL HIM!", "No, nothing starnge." }, null);

        DialogueNode D11_Node21 = new DialogueNode("What are you talking about?", new string[] { "She gave me a poison to kill hum!" }, null);
        DialogueNode D11_Node22 = new DialogueNode("Glad to hear it! Pour me a Vodka, please.", null, null);

        DialogueNode D11_Node3 = new DialogueNode("This is very serious. I will arrest her immediately!", new string[] { "Next." }, null);

        D11_Node1.SetNextDialogueNode(new DialogueNode[] { D11_Node21, D11_Node22 });
        D11_Node21.SetNextDialogueNode(new DialogueNode[] { D11_Node3 });

        Dialogue dialogue11 = new Dialogue(D11_Node1);

        Dialogue.dialogues[10] = dialogue11;
        //
        // D12
        DialogueNode D12_Node1 = new DialogueNode("TOMMY CYCLEMOTOR MOTORCYCLE CYMOTORCLE TOMMYYYYYY!!! KILL KILL KILL KILL KILL", new string[] { "Are You okay mister?" }, null);
        DialogueNode D12_Node2 = new DialogueNode("AUTOGRAPH. T-shirt. MOTORCYCLE. WHYYYY. WHYYY DIDN'T HE GIVE IT TO ME???? SHOOT. HIM. Shoot shoot shoot. VODKA. GIVE ME VODKA! VODKA FOR MOTORKILLER, new MOTORCYCLE new!!!", null, null);

        D12_Node1.SetNextDialogueNode(new DialogueNode[] { D12_Node2 });

        Dialogue dialogue12 = new Dialogue(D12_Node1);
        Dialogue.dialogues[11] = dialogue12;
        //
        // D13
        DialogueNode D13_Node1 = new DialogueNode("Kid, you won't believe what just happened. Some crazy guy almost killed Tommy just now, and I saw him in time and knocked him to the floor. My colleagues have already taken him away.", new string[] { "Next." }, null);
        DialogueNode D13_Node2 = new DialogueNode("Ugh, I need a drink after that. WAIT A MINUTE! WHAT IS THIS? POISON?", new string[] { "Next." }, null);
        DialogueNode D13_Node3 = new DialogueNode("You have the right to remain silent. Anything you say can and will be used against you in a court of law. You have the right to have an attorney present during questioning. If you cannot afford an attorney, one will be appointed for you. Do you understand these rights?", new string[] { "Next." }, null);
        DialogueNode D13_Node4 = new DialogueNode("I'm disappointed in you, kid.", new string[] {"Next" }, null);

        D13_Node1.SetNextDialogueNode(new DialogueNode[] { D13_Node2 });
        D13_Node2.SetNextDialogueNode(new DialogueNode[] { D13_Node3 });
        D13_Node3.SetNextDialogueNode(new DialogueNode[] { D13_Node4 });

        Dialogue dialogue13 = new Dialogue(D13_Node1);
        Dialogue.dialogues[12] = dialogue13;
        //



    }

    // Update is called once per frame
    void Update()
    {
        if (HumanSpawner.transform.childCount != 0)
        {
            GameObject current_human = HumanSpawner.transform.GetChild(0).gameObject;
            DialogueWindow.SetActive(current_human.GetComponent<HumanScript>().startDialogue);
            if (current_human.GetComponent<HumanScript>().startDialogue)
            {
                PlayDialogue(Dialogue.dialogues[current_human.GetComponent<HumanScript>().id]);
            }
        }
    }

    public void PlayDialogue(Dialogue dialogue)
    {
        DialogueWindow.SetActive(true);

        if (choosen_dialogue_option != -1 && dialogue.GetCurrentNode().GetReplica() == "I'm disappointed in you, kid.")
        {
            GameControllerScript.Ending = 4;
        }

        if (choosen_dialogue_option != -1)
        {
            dialogue.Next(choosen_dialogue_option);
            choosen_dialogue_option = -1;
        }

        DialogueNode current_node = dialogue.GetCurrentNode();

        if (current_node != null)
        {
            DialogueWindow.transform.Find("Background").transform.Find("Replica").GetComponent<TextMeshProUGUI>().text = current_node.GetReplica();

            if (!isPoisonAlreadyTriggered && (current_node.GetReplica() == "I knew you are a good guy. Mix it with Vodka and give it to Tommy, but there are a lot of cops here, be careful. And now, please, give me a White Russian." || current_node.GetReplica() == "I'll just leave it here. Think about it, mix it with Vodka and give it to Tommy. Now, please, give me a White Russian." || current_node.GetReplica() == "Thank you SO MUCH! Mix it with Vodka and give it to Tommy. Now, please, give me a White Russian."))
            {
                GameControllerScript.isGotPoison = true;
                isPoisonAlreadyTriggered = true;
            }

            if (current_node.GetReplica() == "This is very serious. I will arrest her immediately!")
            {
                BarToolScript.isPoisonGivenToPolice = true;
                GameControllerScript.Ending = 5;
            }

            for (int i = 0; i < DialogueWindow.transform.Find("Background").transform.childCount - 1; i++)
            {
                DialogueWindow.transform.Find("Background").transform.GetChild(i).gameObject.SetActive(false);
            }

            string[] dialogue_options = current_node.GetDialogueOptions();

            if (dialogue_options != null)
            {
                for (int i = 0; i < dialogue_options.Length; i++)
                {
                    DialogueWindow.transform.Find("Background").transform.GetChild(i).gameObject.SetActive(true);
                    DialogueWindow.transform.Find("Background").transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString() + ". " + dialogue_options[i];
                }
            }
            else
            {
                current_human.GetComponent<HumanScript>().isReadyForCocktail = true;
                if (current_human.GetComponent<HumanScript>().isGotCocktail)
                {
                    dialogue.Next(0);
                    choosen_dialogue_option = -1;
                }
            }
        }
        else
        {
            current_human.GetComponent<HumanScript>().isDialogueOver = true;
        }
        
    }
}
