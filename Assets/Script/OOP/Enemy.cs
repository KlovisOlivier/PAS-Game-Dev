using UnityEngine;
using System;

// Pastikan enum ini ada (bisa ditaruh di luar class atau di script terpisah)
public enum StateZombie
{
    IDLE,
    PATROL,
    CHASE,
    ATTACK
}

public class Enemy : MonoBehaviour
{
    [SerializeField] private int xhp = 100;
    public float ms = 2f;

    protected Transform player;

    [Header("State Machine")]
    [SerializeField] private float JarakDeteksi = 6f;
    [SerializeField] private float JarakSerang = 1.5f;
    [SerializeField] private float JedaSerang = 1f;

    // State Now
    private StateZombie state = StateZombie.IDLE;
    private float waktuSerangTerakhir;

    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        PeriksaTransisi();
        
        switch(state)
        {
            case StateZombie.IDLE: PerilakuIdle(); break;
            case StateZombie.PATROL: PerilakuPatrol(); break;
            case StateZombie.CHASE: PerilakuChase(); break;
            case StateZombie.ATTACK: PerilakuAttack(); break;
        }
    }

    public float JarakKePlayer()
    {
        if (player == null) return Mathf.Infinity;
        return Vector2.Distance(transform.position, player.position);
    }

    void PeriksaTransisi()
    {
        float jarak = JarakKePlayer();

        if (jarak <= JarakSerang)
        {
            state = StateZombie.ATTACK;
        }
        else if (jarak <= JarakDeteksi)
        {
            state = StateZombie.CHASE;
        }
        else
        {
            state = StateZombie.PATROL;
        }  
    }

    public void Kejar()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            ms * Time.deltaTime
        );
    }

    public virtual void Serang()
    {
        // Logika tambahan jika musuh punya animasi serang
        // Debug.Log("Enemy melakukan animasi serangan!");
    }

    void PerilakuIdle()
    {
        // Debug.Log("Enemy sedang IDLE");
    }

    void PerilakuPatrol()
    {
        // Debug.Log("Enemy sedang PATROL");
    }

    void PerilakuChase()
    {
        Kejar();
        // Debug.Log("Enemy sedang CHASE");
    }

    void PerilakuAttack()
    {
        // Harus tetap memanggil Kejar() agar musuh benar-benar menabrak player
        Kejar(); 
        Serang();
    }

    // Fungsi untuk mendeteksi tabrakan dengan Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Berhasil hit Player!");

            // Jika script PlayerController kamu memiliki fungsi TakeDamage, panggil di sini:
            // collision.gameObject.GetComponent<PlayerController>().TakeDamage(10);

            // Hancurkan musuh setelah berhasil menyerang
            Destroy(gameObject);
        }
    }
}