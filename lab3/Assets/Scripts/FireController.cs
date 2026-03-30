using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1.5f; // Стрільба кожні 1.5 сек

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Створюємо кулю на позиції FirePoint з таким же обертанням
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}