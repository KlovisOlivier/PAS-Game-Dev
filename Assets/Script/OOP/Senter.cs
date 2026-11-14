using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Senter : MonoBehaviour
{
    public PlayerMovement player;
    public Light2D cahaya;
    public float kecepatanPutar = 15f;
    public bool menyala = true;

    void Start()
    {
        if (player == null) player = GetComponentInParent<PlayerMovement>();
        if (cahaya == null) cahaya = GetComponent<Light2D>();
        cahaya.enabled = menyala;
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            menyala = !menyala;
            cahaya.enabled = menyala;
        }

        Vector2 arah = player.ArahHadap;
        float sudut = Mathf.Atan2(arah.y, arah.x) * Mathf.Rad2Deg - 90f;
        Quaternion target = Quaternion.Euler(0f, 0f, sudut);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, kecepatanPutar * Time.deltaTime);
    }
}