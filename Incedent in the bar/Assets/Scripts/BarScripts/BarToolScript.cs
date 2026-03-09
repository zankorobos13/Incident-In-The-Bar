using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarToolScript : MonoBehaviour
{
    public GameObject TextBox;
    public Type type;
    public static bool isPoisonUsed = false;
    public static bool isPoisonGivenToPolice = false;
    private bool isOnObject;
    // Start is called before the first frame update
    void Start()
    {
        isOnObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnObject)
        {
            TextBox.transform.position = Input.mousePosition + new Vector3(100, 100, 0);
            TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = type.ToString();
            TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
            TextBox.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = new Vector2(type.ToString().Length * 20 + 20, TextBox.transform.Find("Background").GetComponent<RectTransform>().sizeDelta.y);

            switch (type)
            {
                case Type.Wine:
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = Color.red;
                    break;
                case Type.Vodka:
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = Color.cyan;
                    break;
                case Type.Rum:
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = new Color(1, 0.7f, 0);
                    TextBox.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = new Vector2(type.ToString().Length * 20 + 30, TextBox.transform.Find("Background").GetComponent<RectTransform>().sizeDelta.y);
                    break;
                case Type.Lemon:
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = Color.yellow;
                    break;
                case Type.Lime:
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                    break;
                case Type.Orange:
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = new Color(1, 0.7f, 0);
                    break;
                case Type.Milk:
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = Color.white;
                    break;
                case Type.Syrup:
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = new Color(1, 0.7f, 0);
                    break;
                case Type.Shaker:
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = Color.red;
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Italic;
                    break;
                case Type.Poison:
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                    TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Italic;
                    break;
                default:
                    break;
            }

        }

        if ((isPoisonUsed || isPoisonGivenToPolice) && type == Type.Poison)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        TextBox.SetActive(true);
        isOnObject = true;
    }

    private void OnMouseExit()
    {
        TextBox.SetActive(false);
        isOnObject = false;
    }


    private void OnMouseDown()
    {
        if (CrafterScript.isCrafterOpened && type != Type.Shaker)
        {
            CrafterScript.Craft.AddComponent(type);
        }
    }
    public enum Type
    {
        Void,
        Wine,
        Vodka,
        Rum,
        Lemon,
        Lime,
        Orange,
        Milk,
        Syrup,

        Shaker,
        Poison
    }
}
