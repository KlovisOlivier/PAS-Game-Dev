using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int maxHP = 100;
    public int currentHP;
    public Slider healthBar; // Tarik UI Slider Healthbar ke sini di Inspector
    public Animator animator; // Tarik komponen Animator ke sini

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
        UpdateHealthBar();
    }

    void Update()
    {
        // Bergerak dalam 4 arah (WASD / Panah)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Animasi simpel (Pastikan parameter "Speed" ada di Animator)
        if (animator != null)
        {
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UpdateHealthBar();
        if (currentHP <= 0)
        {
            Debug.Log("Player Mati!");
            // Tambahkan logika game over di sini nanti
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHP / maxHP;
        }
    }
}