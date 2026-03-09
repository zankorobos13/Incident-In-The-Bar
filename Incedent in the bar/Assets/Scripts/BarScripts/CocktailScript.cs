using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocktailScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[11];
    public CrafterScript.Cocktail cocktail;
    public bool isOnObject = false;
    public bool isRecentlyReleasedFromObject = false;

    public bool isDragging = false;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        isOnObject = false;
        isRecentlyReleasedFromObject = false;
        if (cocktail == CrafterScript.Cocktail.Poisoned_Vodka)
        {
            BarToolScript.isPoisonUsed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            gameObject.transform.position = rayPoint;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        }

        if (BarToolScript.isPoisonGivenToPolice == true && cocktail == CrafterScript.Cocktail.Poisoned_Vodka)
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseEnter()
    {
        isOnObject = true;
    }

    private void OnMouseExit()
    {
        isOnObject = false;
        isRecentlyReleasedFromObject = true;
    }

    private void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
