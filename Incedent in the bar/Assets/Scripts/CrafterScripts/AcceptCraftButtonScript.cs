using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptCraftButtonScript : MonoBehaviour
{
    public GameObject Crafter;
    public GameObject CocktailPrefab;
    public GameObject CocktailSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!CrafterScript.Craft.IsFullEmpty())
        {
            CrafterScript.Cocktail cocktail = CrafterScript.Craft.CheckRecipe();

            if (cocktail != CrafterScript.Cocktail.Void)
            {
                CrafterScript.Craft.ToDefault();
                GameObject cocktail_object = Instantiate(CocktailPrefab, CocktailSpawner.transform);
                cocktail_object.GetComponent<CocktailScript>().cocktail = cocktail;
                cocktail_object.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().sprite = cocktail_object.GetComponent<CocktailScript>().sprites[(int)cocktail];
                cocktail_object.transform.position = new Vector3 (cocktail_object.transform.position.x + Random.Range(-1f, 1f) * 0.6f, cocktail_object.transform.position.y +  Random.Range(-1f, 1f) * 0.6f, 0);
                if (cocktail != CrafterScript.Cocktail.Wine && cocktail != CrafterScript.Cocktail.Daiquiri)
                    cocktail_object.GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 0.55f);
            }

        }
            
        
    }
}
