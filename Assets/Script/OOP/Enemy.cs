using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float ms = 2f;

    protected Transform player;

    [Header("State Machine")]
    [SerializeField] private float JarakDeteksi = 6f;
    [SerializeField] private float JarakSerang = 1.5f;
    [SerializeField] private float JedaSerang = 1f;

    private StateZombie state = StateZombie.IDLE;
    private float waktuSerangTerakhir;

    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        PeriksaTransisi();

        switch (state)
        {
            case StateZombie.IDLE:   PerilakuIdle(); break;
            case StateZombie.PATROL: PerilakuPatrol(); break;
            case StateZombie.CHASE:  PerilakuChase(); break;
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
            state = StateZombie.ATTACK;
        else if (jarak <= JarakDeteksi)
            state = StateZombie.CHASE;
        else
            state = StateZombie.PATROL;
    }

    public void Kejar()
    {
        if (player == null) return;
        transform.position = Vector2.MoveTowards(transform.position, player.position, ms * Time.deltaTime);
    }

    public virtual void Serang()
    {
        Debug.Log("Enemy Serang");
    }

    void PerilakuIdle()   { /* diam */ }
    void PerilakuPatrol() { /* bisa ditambah gerak bolak-balik */ }
    void PerilakuChase()  { Kejar(); }
    void PerilakuAttack()
    {
        if (Time.time - waktuSerangTerakhir >= JedaSerang)
        {
            Serang();
            waktuSerangTerakhir = Time.time;
        }
    }
}