using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [Tooltip("Kosongkan jika Animator ada di object ini atau child-nya")]
    public Animator animator;

    private Vector2 posisiTerakhir;
    private Vector2 arahTerakhir = Vector2.down;

    void Start()
    {
        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        posisiTerakhir = transform.position;
    }

    void LateUpdate()
    {
        if (animator == null || Time.deltaTime == 0f) return;

        Vector2 posisiSekarang = transform.position;
        Vector2 gerak = (posisiSekarang - posisiTerakhir) / Time.deltaTime;
        posisiTerakhir = posisiSekarang;

        float speed = gerak.magnitude;

        if (speed > 0.05f)
        {
            // Pilih 4 arah: sumbu yang paling dominan
            if (Mathf.Abs(gerak.x) > Mathf.Abs(gerak.y))
                arahTerakhir = new Vector2(Mathf.Sign(gerak.x), 0f);
            else
                arahTerakhir = new Vector2(0f, Mathf.Sign(gerak.y));
        }

        animator.SetFloat("MoveX", arahTerakhir.x);
        animator.SetFloat("MoveY", arahTerakhir.y);
        animator.SetFloat("Speed", speed > 0.05f ? 1f : 0f);
    }
}