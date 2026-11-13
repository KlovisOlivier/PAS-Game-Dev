using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalItem;
    private int itemTerkumpul = 0;
    private bool gameSelesai = false;

    void Start()
    {
        Time.timeScale = 1f; // pastikan game jalan normal saat mulai / restart
        totalItem = GameObject.FindGameObjectsWithTag("Item").Length;
        Debug.Log("Total item: " + totalItem);
    }

    public void AmbilItem()
    {
        if (gameSelesai) return;

        itemTerkumpul++;
        Debug.Log("Item terkumpul: " + itemTerkumpul + "/" + totalItem);

        if (itemTerkumpul >= totalItem)
            Menang();
    }

    public void Kalah()
    {
        if (gameSelesai) return;

        gameSelesai = true;
        Debug.Log("KAMU KALAH!");
        Time.timeScale = 0f; // freeze game
    }

    void Menang()
    {
        if (gameSelesai) return;

        gameSelesai = true;
        Debug.Log("KAMU MENANG!");
        Time.timeScale = 0f; // freeze game
    }
}