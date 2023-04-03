using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public PlayerControl selectedUnit;

    public TMP_Text nameText;

    public Animator namePanelAnimator;

    public Image healthImage;
    public PizzaSteve healthPS;
    public GameObject pizzaSteve;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = healthPS.score / 100;
        if (healthPS.score > 99)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject pizza = Instantiate(pizzaSteve, pizzaSteve.transform.position, Quaternion.identity);
                float rotXAmount = Random.Range(-50, -10);
                float rotYAmount = Random.Range(0, 10);
                pizza.transform.Rotate(rotXAmount, rotYAmount, 0);
                pizza.transform.localScale = Vector3.one;
                Rigidbody rb = pizza.GetComponent<Rigidbody>();
                rb.AddForce(pizza.transform.forward * 1);
            }
            pizzaSteve.SetActive(false);

            healthPS.score = 99;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray) == false)
            {
                if (selectedUnit != null)
                {
                    selectedUnit.selected = false;
                    selectedUnit.bodyRend.material.color = selectedUnit.defaultColor;

                    selectedUnit = null;

                    namePanelAnimator.SetTrigger("fadeOut");
                }
            }
        }

    }

    public void FireButtonClicked()
    {
        selectedUnit.fire.SetActive(true);
        Invoke(nameof(disableFire), 2f);
    }

    public void disableFire() 
    {
        selectedUnit.fire.SetActive(false);
    }

}
