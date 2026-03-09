using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafterSlotScript : MonoBehaviour
{
    public int slot_id;
    public Sprite[] sprites = new Sprite[11];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)CrafterScript.Craft.GetComponents()[slot_id]];
    }

    private void OnMouseDown()
    {
        CrafterScript.Craft.RemoveComponent(slot_id);
    }
}
