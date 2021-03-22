using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //Reference to the items within our inventory slot.
    public Image icon;
    public Button removeButton;
    //Since we only have health pack, we can do healAmount.
    public int healAmount = 20;
    Item item;
    PlayerBehavior player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();

    }
    public void AddItem(Item newItem)
    {
        //To add item to inventory, set the sprite to the icon, make it able to be pressed and deleted.
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot()
    {
        //delete the item when used(opposite of AddItem)
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        //When you press the x, delete the item itself.
        Inventory.instance.Remove(item);
    }
    public void UseItem()
    {
        //Use the healing pack
        if(item != null)
        {
            //Heal the player by a certain amount, then delete item.
            item.Heal(healAmount, player);
            item.RemoveFromInventory();
        }
    }
}
