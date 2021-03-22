using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //What is in an item?
    public PlayerBehavior currentPlayer;
    new public string name = "New Item";
    public Sprite icon = null;

    public virtual void Heal(int amount, PlayerBehavior currentPlayer)
    {
        //increase the player health by the amount the pack gives.
        currentPlayer.currentHealth += amount;
}
    public void RemoveFromInventory()
    {
        //remove the item from the inventory.
        Inventory.instance.Remove(this);
    }
}
