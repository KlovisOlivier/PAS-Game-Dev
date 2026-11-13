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

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        // Pastikan array gambar sudah diisi di Inspector
        if (healthSprites.Length > 0 && healthBarImage != null)
        {
            // Hitung persentase sisa darah (dari 0.0 sampai 1.0)
            float healthPercentage = currentHealth / maxHealth;

            // Tentukan index gambar mana yang cocok dengan sisa darah
            int spriteIndex = Mathf.RoundToInt(healthPercentage * (healthSprites.Length - 1));

            // Ganti gambar UI dengan gambar dari array
            healthBarImage.sprite = healthSprites[spriteIndex];
        }
    }

    void Die()
    {
        Debug.Log("Player Mati!");
        // Tambahkan efek mati di sini
    }
}