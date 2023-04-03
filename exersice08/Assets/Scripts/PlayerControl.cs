using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public string unitName;
    public Renderer bodyRend;
    public Color hoverColor;
    public Color selectedColor;
    public Color defaultColor;
    public bool selected = false;
    public GameObject fire;


    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = bodyRend.material.color;

        GameObject gmObj = GameObject.Find("GameManager");
        gm = gmObj.GetComponent<GameManager>();
    }

  

    // Update is called once per frame
    void Update()
    {
 
    
    }

    private void OnMouseEnter()
    {
        if (selected == false)
        {
            bodyRend.material.color = hoverColor;
        }
    }
    private void OnMouseExit()
    {
        if (selected == false)
        {
            bodyRend.material.color = defaultColor;
        }
    }
    private void OnMouseDown()
    {
        if (gm.selectedUnit != null)
        {
            // if we're here, something was already selected!
            // 1. Deselect it
            gm.selectedUnit.selected = false;
            gm.selectedUnit.bodyRend.material.color = gm.selectedUnit.defaultColor;
        }
        selected = true;
        bodyRend.material.color = selectedColor;

        if (gm.selectedUnit == null)
        {
            gm.namePanelAnimator.SetTrigger("fadeIn");
        }
       

        gm.selectedUnit = this;
        gm.nameText.text = unitName;
    }

}
