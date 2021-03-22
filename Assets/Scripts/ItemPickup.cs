using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        //What happens when player interacts with this?
        base.Interact();

        PickUp();
    }
    void PickUp()
    {
        //Pick up item and add to inventory.
        bool wasPickedUp = Inventory.instance.Add(item);
        //Destroy the item in the game after picked up.
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //When you enter the trigger (collider), pick it up
        PickUp();
    }
}
