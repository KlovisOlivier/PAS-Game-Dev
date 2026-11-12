using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemDetails itemData; // Masukkan data item (ScriptableObject atau Class) di Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Mencari InventoryManager di dalam scene
            InventoryManager inventory = FindAnyObjectByType<InventoryManager>();
            
            if (inventory != null)
            {
                inventory.AddItem(itemData); // Memasukkan item ke slot yang kosong
                Destroy(gameObject); // Menghancurkan objek di arena
            }
        }
    }
}