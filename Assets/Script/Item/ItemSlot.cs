using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int itemQuantity;
    public Sprite itemIcon;
    public bool isFull;

    public ItemDetails ItemDetails => itemDetails;

    [SerializeField] private int maxStackSize = 99;
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
    [SerializeField] private GameObject selectedPanel;

    private ItemDetails itemDetails;
    private InventoryManager inventory;

    public void Setup(InventoryManager owner)
    {
        inventory = owner;
        SetSelected(false);
        if (quantityText != null) quantityText.enabled = false;
        if (itemImage != null) itemImage.enabled = false;
    }

    public bool CanStackWith(string otherItemName)
    {
        return isFull && itemName == otherItemName && itemQuantity < maxStackSize;
    }

    public void AddItem(ItemDetails item)
    {
        if (CanStackWith(item.ItemName))
        {
            itemQuantity += item.Quantity;
            if (itemQuantity > maxStackSize) itemQuantity = maxStackSize;
        }
        else
        {
            itemDetails = item;
            itemName = item.ItemName;
            itemQuantity = item.Quantity;
            itemIcon = item.ItemIcon;
            isFull = true;
        }

        if (quantityText != null)
        {
            quantityText.text = itemQuantity.ToString();
            quantityText.enabled = true;
        }
        if (itemImage != null)
        {
            itemImage.sprite = itemIcon;
            itemImage.enabled = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isFull || inventory == null) return;
        inventory.SelectSlot(this);
    }

    public void SetSelected(bool selected)
    {
        if (selectedPanel != null)
            selectedPanel.SetActive(selected);
    }
}