using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetailsPanel : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemQuantityText;
    [SerializeField] private TMP_Text itemDescriptionText;

    public void Show(ItemDetails item)
    {
        if (item == null) return;

        if (itemImage != null) itemImage.sprite = item.ItemIcon;
        if (itemNameText != null) itemNameText.text = item.ItemName;
        if (itemQuantityText != null) itemQuantityText.text = "Quantity: " + item.Quantity;
        if (itemDescriptionText != null) itemDescriptionText.text = item.Description;
    }
}