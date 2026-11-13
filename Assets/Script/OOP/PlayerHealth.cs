using UnityEngine;
using UnityEngine.UI; // Wajib dipanggil untuk mengakses komponen UI

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("UI References")]
    public Image healthBarFill; // Tempat kita memasukkan HealthBarFill

    void Start()
    {
        // Set darah penuh saat game dimulai
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        // TESTING: Tekan tombol Spasi untuk mengurangi darah
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10f); // Kurangi 10 darah tiap pencet spasi
        }
    }

    // Fungsi untuk menerima damage
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        // Mencegah darah menjadi minus
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Fungsi untuk menambah darah (Heal)
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    // Fungsi untuk mengupdate visual UI bar
    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            // fillAmount menerima nilai dari 0.0 sampai 1.0
            // Jadi kita bagi currentHealth dengan maxHealth
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player Mati!");
        // Tambahkan efek mati di sini (misal animasi mati, game over panel, dll)
        // Destroy(gameObject); 
    }
}