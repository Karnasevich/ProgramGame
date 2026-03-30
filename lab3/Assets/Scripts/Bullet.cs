using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 15f; // Знищення через 15 секунд

    void Start()
    {
        // Автоматичне знищення об'єкта
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Куля завжди летить "вперед" відносно свого обертання
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}