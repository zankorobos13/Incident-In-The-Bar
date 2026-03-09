using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[6];
    public float speed = 3f;
    public int id;
    public CrafterScript.Cocktail cocktail;
    public bool isReadyForCocktail = false;
    public bool startDialogue = false;
    public bool isDialogueOver = false;
    public bool isGotCocktail = false;


    private float initial_y;


    private bool isCollided = false;
    private Collider2D collision;

    // Start is called before the first frame update
    void Start()
    {
        if (GameControllerScript.Ending != 0 && GameControllerScript.Ending != 2)
            SceneManager.LoadScene("Ending");
        else if (GameControllerScript.Ending == 2 && id == 12)
        {
            SceneManager.LoadScene("Ending");
        }

        DialogueSystemScript.current_human = gameObject;
        initial_y = gameObject.transform.position.y;
        isReadyForCocktail = false;
        startDialogue = false;
        isDialogueOver = false;
        isGotCocktail = false;

        if (id == 0)
        {
            cocktail = CrafterScript.Cocktail.Daiquiri;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (id == 1)
        {
            cocktail = CrafterScript.Cocktail.Wine;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (id == 2)
        {
            cocktail = CrafterScript.Cocktail.Screwdriver;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (id == 3)
        {
            cocktail = CrafterScript.Cocktail.Rum_Punch;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (id == 4)
        {
            cocktail = CrafterScript.Cocktail.Vodka_Sour;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
        else if (id == 5)
        {
            cocktail = CrafterScript.Cocktail.Vodka;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (id == 6)
        {
            cocktail = CrafterScript.Cocktail.Rum_Sunset;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (id == 7)
        {
            cocktail = CrafterScript.Cocktail.White_Russian;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if (id == 8)
        {
            cocktail = CrafterScript.Cocktail.Mulled_Wine;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (id == 9)
        {
            cocktail = CrafterScript.Cocktail.Vodka;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (id == 10)
        {
            cocktail = CrafterScript.Cocktail.Vodka;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
        else if (id == 11)
        {
            cocktail = CrafterScript.Cocktail.Vodka;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[5];
        }
        else if (id == 12)
        {
            cocktail = CrafterScript.Cocktail.Rum;
            gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[4];
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < -7.4)
        {
            gameObject.transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, initial_y + 0.1f * (float)System.Math.Sin(5*gameObject.transform.position.x), 0);
        }
        else if (startDialogue == false)
        {
            startDialogue = true;
        }

        if (isCollided && isReadyForCocktail && !collision.gameObject.GetComponent<CocktailScript>().isDragging && collision.gameObject.GetComponent<CocktailScript>().cocktail == cocktail)
        {
            GameControllerScript.isNeedToDisableTextBox = true;
            Destroy(collision.gameObject);
            isCollided = false;
            isGotCocktail = true;
        }
        else if (isCollided && isReadyForCocktail && !collision.gameObject.GetComponent<CocktailScript>().isDragging && cocktail == CrafterScript.Cocktail.Vodka && collision.gameObject.GetComponent<CocktailScript>().cocktail == CrafterScript.Cocktail.Poisoned_Vodka )
        {
            GameControllerScript.isNeedToDisableTextBox = true;
            Destroy(collision.gameObject);
            isCollided = false;
            isGotCocktail = true;

            if (id == 9)
            {
                // Rocker
                GameControllerScript.Ending = 1;
            }
            else if (id == 10)
            {
                // Policeman
                GameControllerScript.Ending = 2;
            }
            else if (id == 11)
            {
                // Psycho
                GameControllerScript.Ending = 3;
            }
        }
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
