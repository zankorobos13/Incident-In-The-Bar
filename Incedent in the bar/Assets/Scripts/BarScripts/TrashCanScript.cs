using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashCanScript : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject CocktailSpawner;

    private bool isOnObject = false;
    private bool isCollided = false;
    private Collider2D collision;
    // Start is called before the first frame update
    void Start()
    {
        isOnObject = false;
        isCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnObject)
        {
            TextBox.transform.position = Input.mousePosition + new Vector3(100, 100, 0);
            TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Trash Can";
            TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Italic;
            TextBox.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = new Vector2("Trash Can".Length * 20 + 20, TextBox.transform.Find("Background").GetComponent<RectTransform>().sizeDelta.y);
            TextBox.transform.Find("Text").GetComponent<TextMeshProUGUI>().color = Color.red;
        }

        if (isCollided && collision.gameObject.transform.IsChildOf(CocktailSpawner.transform) && !collision.gameObject.GetComponent<CocktailScript>().isDragging)
        {
            GameControllerScript.isNeedToDisableTextBox = true;
            Destroy(collision.gameObject);
            isCollided = false;
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

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        this.collision = collision;
        isCollided = true;
                
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollided = false;
    }

}
