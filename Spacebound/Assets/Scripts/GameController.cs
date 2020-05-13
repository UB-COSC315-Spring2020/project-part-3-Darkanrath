using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    bool hasPickaxe = false;
    bool hasAxe = false;
    bool hasSword = false;
    bool pickaxeEquipped = false;
    bool axeEquipped = false;
    bool swordEquipped = false;

    public GameObject equippedItem;

    public Canvas InventoryUI;

    bool harvestWood = false;
    bool harvestCoal = false;

    int pickaxeLevel = 0;
    int axeLevel = 0;
    int swordLevel = 0;

    int coalAmt = 0;
    int woodAmt = 0;
    int ironAmt = 0;

    public Text coal;
    public Text wood;
    public Text iron;

    public Text interactableText;
    string interaction;

    public GameObject swordSlotImage;
    public GameObject axeSlotImage;
    public GameObject pickaxeSlotImage;

    public Sprite ironAxe;
    public Sprite ironSword;
    public Sprite ironPickaxe;

    int health = 100;

    private void Update()
    {
        // If player health drops to 0, they die
        if (health <= 0)
        {
            Destroy(this.gameObject);       
        }

        // Open & close inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (InventoryUI.enabled == true)
            {
                InventoryUI.enabled = false;
            }
            else if (InventoryUI.enabled == false)
            {
                InventoryUI.enabled = true;
            }
        }

        // Interact with objects
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interaction == "ironaxe")
            {
                hasAxe = true;
                axeLevel = 1;
                axeSlotImage.GetComponent<Image>().sprite = ironAxe;
                axeSlotImage.SetActive(true);
            }
            else if (interaction == "ironpickaxe")
            {
                hasPickaxe = true;
                pickaxeLevel = 1;
                pickaxeSlotImage.GetComponent<Image>().sprite = ironPickaxe;
                pickaxeSlotImage.SetActive(true);
            }
            else if (interaction == "ironsword")
            {
                hasSword = true;
                swordLevel = 1;
                swordSlotImage.GetComponent<Image>().sprite = ironSword;
                swordSlotImage.SetActive(true);
            }
        }

        // Switch tools
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasSword == true)
        {
            swordEquipped = true;
            axeEquipped = false;
            pickaxeEquipped = false;
            equippedItem.GetComponent<SpriteRenderer>().sprite = ironSword;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && hasPickaxe == true)
        {
            pickaxeEquipped = true;
            axeEquipped = false;
            swordEquipped = false;
            equippedItem.GetComponent<SpriteRenderer>().sprite = ironPickaxe;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && hasAxe == true)
        {
            axeEquipped = true;
            swordEquipped = false;
            pickaxeEquipped = false;
            equippedItem.GetComponent<SpriteRenderer>().sprite = ironAxe;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (harvestWood == true)
            {
                HarvestWood();
            }
            else if (harvestCoal == true)
            {

            }
            else { }

        }
    }

    private void Inventory()
    {
        
    }

    public void HarvestWood()
    {

        if (hasAxe == true && axeEquipped == true && axeLevel >= 1)
        {
            woodAmt += 3;
            wood.text = "" + woodAmt;
            Debug.Log("Harvested Wood");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interactables(other.tag);

        Harvestable(other.tag);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactableText.text = "";
        interaction = "";

        harvestWood = false;
        Debug.Log("No more wood");
    }

    private void Interactables(string interactable)
    {
        if (interactable == "ironaxe")
        {
            interactableText.text = "Press 'E' to pick up Iron Axe";
            interaction = "ironaxe";
        }
        else if (interactable == "ironpickaxe")
        {
            interactableText.text = "Press 'E' to pick up an Iron Pickaxe";
            interaction = "ironpickaxe";
        }
        else if (interactable == "ironsword")
        {
            interactableText.text = "Press 'E' to pick up an Iron Sword";
            interaction = "ironsword";
        }
    }

    public void Harvestable (string type)
    {
        if (type == "wood")
        {
            harvestWood = true;
            Debug.Log("Wood");
        }
    }
}
