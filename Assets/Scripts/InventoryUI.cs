using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //Reference to our Inventory.
    public Transform itemsParent;
    public GameObject inventoryUI;
    public bool isInventory = false;
    public GameController gameController;

    Inventory inventory;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        //If user presses b or i, open inventory.
        if (Input.GetButtonDown("Inventory"))
        {
            isInventory = !isInventory;
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        //if you opened inventory, stop time and make cursor visible, else, go back to the game.
        if (isInventory)
        {
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    void UpdateUI()
    {
        //Add items or remove them, run a for loop to check which slots are filled or not.
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
