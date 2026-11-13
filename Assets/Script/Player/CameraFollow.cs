using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 
    public float smoothSpeed = 5f; 
    public Vector3 offset = new Vector3(0, 0, -10f);// Z harus -10 agar layar tidak blank di 2D

    void LateUpdate() // LateUpdate digunakan khusus kamera agar tidak patah-patah
    {
        if (player != null)
        {
            // Menghitung posisi tujuan kamera
            Vector3 targetPosition = player.position + offset;
            
            // Bergerak perlahan (smooth) ke posisi tujuan
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}