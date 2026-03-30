using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 2f;
    public float lifetime = 30f; // Знищення через 30 секунд
    private Vector3 moveDirection;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Метод, який викликатиме спавнер для передачі напрямку
    public void SetDirection(Vector3 targetPosition)
    {
        moveDirection = (targetPosition - transform.position).normalized;
    }

    void Update()
    {
        if (moveDirection != Vector3.zero)
        {
            // Метеорит летить по заданому напрямку
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
}