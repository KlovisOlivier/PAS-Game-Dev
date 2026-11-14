using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Pengaturan Gerak")]
    public float kecepatan = 5f;
    private Vector2 arahGerak;
    private Vector2 arahTerakhir = Vector2.down;
    public Vector2 ArahHadap => arahTerakhir;
    private Rigidbody2D rb;
    private InputAction moveAction;

    [Header("Pengaturan Animasi")]
    public Animator animator;

    [Header("Pengaturan Darah")]
    public int maxHP = 100;
    public int currentHP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");

        currentHP = maxHP;
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        BacaInput();
        UpdateAnimasi();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = arahGerak * kecepatan;
    }

    void BacaInput()
    {
        if (moveAction == null) return;

        Vector2 input = moveAction.ReadValue<Vector2>();

        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            arahGerak = new Vector2(Mathf.Sign(input.x), 0f);
        else if (Mathf.Abs(input.y) > 0f)
            arahGerak = new Vector2(0f, Mathf.Sign(input.y));
        else
            arahGerak = Vector2.zero;

        if (arahGerak != Vector2.zero)
            arahTerakhir = arahGerak;
    }

    void UpdateAnimasi()
    {
        if (animator == null) return;

        animator.SetFloat("MoveX", arahTerakhir.x);
        animator.SetFloat("MoveY", arahTerakhir.y);
        animator.SetFloat("Speed", arahGerak.sqrMagnitude);
    }

    // ===== Ambil Item/Koin =====
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AmbilItem();
            }
            Destroy(other.gameObject);
        }
    }
}