using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafterScript : MonoBehaviour
{
    public GameObject Crafter;

    public static bool isCrafterOpened = false;


    public static class Craft
    {
        private static BarToolScript.Type[] components = new BarToolScript.Type[3] { BarToolScript.Type.Void, BarToolScript.Type.Void, BarToolScript.Type.Void };

        private static BarToolScript.Type[,] recipes = new BarToolScript.Type[,]
        {
            { BarToolScript.Type.Vodka, BarToolScript.Type.Orange, BarToolScript.Type.Void},    // Screwdriver
            { BarToolScript.Type.Rum, BarToolScript.Type.Lime, BarToolScript.Type.Syrup },      // Daiquiri
            { BarToolScript.Type.Vodka, BarToolScript.Type.Milk, BarToolScript.Type.Syrup },    // White Russian
            { BarToolScript.Type.Vodka, BarToolScript.Type.Lemon, BarToolScript.Type.Syrup },   // Vodka Sour
            { BarToolScript.Type.Rum, BarToolScript.Type.Orange, BarToolScript.Type.Lemon },    // Rum Punch
            { BarToolScript.Type.Wine, BarToolScript.Type.Orange, BarToolScript.Type.Lemon },   // Mulled Wine
            { BarToolScript.Type.Rum, BarToolScript.Type.Wine, BarToolScript.Type.Orange },     // Rum Sunset
            { BarToolScript.Type.Wine, BarToolScript.Type.Void, BarToolScript.Type.Void},       // Wine
            { BarToolScript.Type.Vodka, BarToolScript.Type.Void, BarToolScript.Type.Void},      // Vodka
            { BarToolScript.Type.Rum, BarToolScript.Type.Void, BarToolScript.Type.Void},        // Rum
            { BarToolScript.Type.Vodka, BarToolScript.Type.Poison, BarToolScript.Type.Void }    // Poisoned Vodka
        };


        public static void AddComponent(BarToolScript.Type component)
        {
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == BarToolScript.Type.Void)
                {
                    components[i] = component;
                    break;
                }
            }
        }

        public static void RemoveComponent(int component_id)
        {
            components[component_id] = BarToolScript.Type.Void;
        }

        public static BarToolScript.Type[] GetComponents()
        {
            return components;
        }

        public static void Print()
        {
            Debug.Log(components[0].ToString() + components[1].ToString() + components[2].ToString());
        }

        public static void ToDefault()
        {
            for (int i = 0; i < components.Length; i++)
                RemoveComponent(i);
        }

        public static Cocktail CheckRecipe()
        {
            for (int i = 0; i < recipes.GetLength(0); i++)
            {
                bool[] isComponentsIn = new bool[3] { false, false, false };
                bool isThisCocktail = true;

                for (int j = 0; j < recipes.GetLength(1); j++)
                    for (int k = 0; k < components.Length; k++)
                        if (components[k] == recipes[i, j])
                            isComponentsIn[j] = true;

                for (int j = 0; j < isComponentsIn.Length; j++)
                {
                    if (isComponentsIn[j] == false)
                    {
                        isThisCocktail = false;
                        break;
                    }
                }

                int void_count_components = 0;
                int void_count_recipe = 0;

                for (int j = 0; j < components.Length; j++)
                    if (components[j] == BarToolScript.Type.Void)
                        void_count_components++;

                for (int j = 0; j < recipes.GetLength(1); j++)
                    if (recipes[i, j] == BarToolScript.Type.Void)
                        void_count_recipe++;



                if (isThisCocktail && void_count_recipe == void_count_components)
                    return (Cocktail)i;
            }

            return Cocktail.Void;
        }

        public static bool IsFullEmpty()
        {
            for (int i = 0; i < components.Length; i++)
                if (components[i] != BarToolScript.Type.Void)
                    return false;
            return true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        isCrafterOpened = false;
        Crafter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

        isCrafterOpened = !isCrafterOpened;
        Crafter.SetActive(isCrafterOpened);
        Craft.ToDefault();
    }

    public enum Cocktail
    {
        Screwdriver,                // Vodka + Orange-
        Daiquiri,                   // Rum + Lime + Syrup-
        White_Russian,              // Vodka + Milk + Syrup-
        Vodka_Sour,                 // Vodka + Lemon + Syrup-
        Rum_Punch,                  // Rum + Orange + Lemon-
        Mulled_Wine,                // Wine + Orange + Lemon-
        Rum_Sunset,                 // Rum + Wine + Orange-
        Wine,                       // Wine-
        Vodka,                      // Vodka-
        Rum,                        // Rum
        Poisoned_Vodka,             // Vodka + Poison
        Void,                       // Nothing
    }
}
