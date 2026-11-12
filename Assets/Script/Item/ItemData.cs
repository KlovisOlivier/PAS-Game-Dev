using UnityEngine;

// Memungkinkan Anda membuat item langsung dari klik kanan di folder Project
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string itemDescription;
    public Sprite itemIcon;
}