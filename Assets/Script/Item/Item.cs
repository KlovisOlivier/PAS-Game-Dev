using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDetails ItemDetails;
    private GrabableItem itemCollector;

    void Awake()
    {
        foreach (MonoBehaviour component in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
        {
            if (component is GrabableItem collector)
            {
                itemCollector = collector;
                break;
            }
        }

        if (itemCollector == null)
            Debug.LogError("Tidak ada komponen yang mengimplementasikan GrabableItem di scene.", this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && ItemDetails != null && itemCollector != null)
        {
            itemCollector.AddItem(ItemDetails);
            Destroy(gameObject);
        }
    }
}