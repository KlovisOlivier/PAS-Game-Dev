using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("UI References")]
    public Image healthBarImage; // Slot untuk komponen Image darahmu
    
    // Array untuk menyimpan potongan gambar darah
    // PENTING: Urutkan dari Index 0 (Darah Kosong) sampai Index terakhir (Darah Penuh)
    public Sprite[] healthSprites; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthSprites.Length > 0 && healthBarImage != null)
        {
            float healthPercentage = currentHealth / maxHealth;

            int spriteIndex = Mathf.RoundToInt(healthPercentage * (healthSprites.Length - 1));

            healthBarImage.sprite = healthSprites[spriteIndex];
        }
    }

    void Die()
{
    Debug.Log("Player Mati!");

    GameManager gm = FindAnyObjectByType<GameManager>();
    if (gm != null)
    {
        gm.Kalah();
    }
    else
    {
        Time.timeScale = 0f; // tetap freeze walau GameManager tidak ada
    }
}
}