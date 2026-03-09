using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCrafterButtonScript : MonoBehaviour
{
    public GameObject Crafter;
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
        Crafter.SetActive(false);
        CrafterScript.isCrafterOpened = false;
    }
}
