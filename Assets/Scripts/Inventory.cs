using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    //Storing items into a list.
    public static Inventory instance;
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        //Set the instance to this if not done so in the unity console.
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory Found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    //How big is our storage.
    public int space = 20;
    public bool Add(Item item)
    {
        //If our storage is full, return
        if (items.Count >= space)
        {
            return false;
        }
        //Add the item to the storage.
        items.Add(item);
        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }
    public void Remove(Item item)
    {
        //Remove the item from the list.
        items.Remove(item); 
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
