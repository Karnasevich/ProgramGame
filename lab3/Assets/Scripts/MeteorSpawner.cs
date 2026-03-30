using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public Transform player; // Посилання на гравця
    public float spawnRate = 3f; // Частота спавну
    public float spawnRadius = 15f; // Відстань спавну від гравця

    [Range(0f, 180f)]
    public float spawnArcAngle = 90f; // "Ширина" арки попереду гравця (загальний кут)

    private float nextSpawnTime = 0f;

    void Update()
    {
        // Якщо час настав і гравець існує на сцені
        if (Time.time >= nextSpawnTime && player != null)
        {
            SpawnMeteorForward();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnMeteorForward()
    {
        // 1. Отримуємо поточний напрямок погляду літака.
        // Оскільки в PlayerMovement ми використовували local +Y як ніс (transform.up),
        // ми отримуємо поточний вектор "вгору" гравця у світових координатах.
        Vector3 playerForward = player.up;

        // 2. Створюємо випадковий кут відхилення в межах нашої арки.
        // Наприклад, якщо arcAngle = 90, ми отримаємо випадкове число від -45 до +45.
        float randomDeviation = Random.Range(-spawnArcAngle / 2f, spawnArcAngle / 2f);

        // 3. Створюємо обертання для цього відхилення по осі Z.
        Quaternion deviationRotation = Quaternion.Euler(0, 0, randomDeviation);

        // 4. Повертаємо вектор напрямку гравця на цей випадковий кут.
        // Отримаємо вектор, який дивиться "кудись вперед і трохи вбік".
        Vector3 spawnDirection = deviationRotation * playerForward;

        // 5. Розраховуємо кінцеву позицію: Позиція гравця + (відкорегований напрямок * радіус).
        Vector3 spawnPos = player.position + (spawnDirection * spawnRadius);


        // --- Решта логіки залишається незмінною ---
        // Спавнимо метеорит
        GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

        // Передаємо метеориту координати гравця
        Meteor meteorScript = meteor.GetComponent<Meteor>();
        if (meteorScript != null)
        {
            meteorScript.SetDirection(player.position);
        }
    }
}