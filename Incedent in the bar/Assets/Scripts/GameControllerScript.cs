using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class GameControllerScript : MonoBehaviour
{
    public GameObject CocktailSpawner;
    public GameObject TextBox;
    public GameObject ONLY_FOR_POISON_TEXTBOX;
    public static bool isNeedToDisableTextBox = false;

    public GameObject HumanSpawner;
    public GameObject HumanPrefab;

    public GameObject PoisonSpawner;
    public GameObject PoisonPrefab;

    public static bool isGotPoison = false;

    public static int Ending = 0;



    
    // Start is called before the first frame update
    void Awake()
    {
        isNeedToDisableTextBox = false;
        isGotPoison = false;
        BarToolScript.isPoisonGivenToPolice = false;
        BarToolScript.isPoisonUsed = false;

        Ending = 0;

        Instantiate(HumanPrefab, HumanSpawner.transform);
    }

    // Update is called once per frame
    void Update()
    {
        CocktailSignature();

        if (isNeedToDisableTextBox)
        {
            TextBox.SetActive(false);
            isNeedToDisableTextBox = false;
        }


        if (HumanSpawner.transform.childCount != 0)
        {
            GameObject human = HumanSpawner.transform.GetChild(0).gameObject;
            if (human.GetComponent<HumanScript>().isDialogueOver)
            {
                int id = human.GetComponent<HumanScript>().id;
                Destroy(human);
                GameObject new_human = Instantiate(HumanPrefab, HumanSpawner.transform);
                new_human.GetComponent<HumanScript>().id = id + 1;
            }
        }

        if (isGotPoison)
        {
            SpawnPoison();
            isGotPoison = false;
        }

        if (Ending == 4)
            SceneManager.LoadScene("Ending");
    }

    private void CocktailSignature()
    {
        for (int i = 0; i < CocktailSpawner.transform.childCount; i++)
        {
            if (CocktailSpawner.transform.GetChild(i).GetComponent<CocktailScript>().isOnObject)
            {
                TextBox.SetActive(true);
                TextBox.transform.position = Input.mousePosition + new Vector3(100, 100, 0);
                TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = CocktailSpawner.transform.GetChild(i).GetComponent<CocktailScript>().cocktail.ToString().Replace("_", " ");
                TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Italic;
                TextBox.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = new Vector2(CocktailSpawner.transform.GetChild(i).GetComponent<CocktailScript>().cocktail.ToString().Length * 20 + 20, TextBox.transform.Find("Background").GetComponent<RectTransform>().sizeDelta.y);

                Color32 color = new Color32(0, 0, 0, 0);

                switch (CocktailSpawner.transform.GetChild(i).GetComponent<CocktailScript>().cocktail)
                {
                    case CrafterScript.Cocktail.Screwdriver:
                        color = new Color32(255, 208, 46, 255);
                        break;
                    case CrafterScript.Cocktail.Daiquiri:
                        color = new Color32(226, 237, 87, 255);
                        break;
                    case CrafterScript.Cocktail.White_Russian:
                        color = new Color32(237, 218, 183, 255);
                        break;
                    case CrafterScript.Cocktail.Vodka_Sour:
                        color = new Color32(234, 224, 163, 255);
                        break;
                    case CrafterScript.Cocktail.Rum_Punch:
                        color = new Color32(255, 187, 63, 255);
                        break;
                    case CrafterScript.Cocktail.Mulled_Wine:
                        color = new Color32(123, 12, 16, 255);
                        break;
                    case CrafterScript.Cocktail.Rum_Sunset:
                        color = new Color32(220, 67, 42, 255);
                        break;
                    case CrafterScript.Cocktail.Wine:
                        color = new Color32(136, 0, 27, 255);
                        break;
                    case CrafterScript.Cocktail.Vodka:
                        color = new Color32(181, 255, 252, 255);
                        break;
                    case CrafterScript.Cocktail.Rum:
                        color = new Color32(215, 113, 12, 255);
                        break;
                    case CrafterScript.Cocktail.Poisoned_Vodka:
                        color = new Color32(0, 255, 0, 255);
                        break;
                    case CrafterScript.Cocktail.Void:
                        break;
                    default:
                        break;
                }

                TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = color;

            }
            if (CocktailSpawner.transform.GetChild(i).GetComponent<CocktailScript>().isRecentlyReleasedFromObject)
            {
                TextBox.SetActive(false);
                CocktailSpawner.transform.GetChild(i).GetComponent<CocktailScript>().isRecentlyReleasedFromObject = false;
            }
        }
    }

    private void SpawnPoison()
    {
        GameObject poison = Instantiate(PoisonPrefab, new Vector3(-8, 0, 0), PoisonSpawner.transform.rotation);
        poison.GetComponent<BarToolScript>().TextBox = ONLY_FOR_POISON_TEXTBOX;
    }

}
