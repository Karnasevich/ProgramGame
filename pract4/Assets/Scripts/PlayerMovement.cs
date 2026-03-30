using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Налаштування руху")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Отримуємо доступ до компонента Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Зчитуємо введення по горизонталі (A/D, стрілки вліво/вправо)
        movement.x = Input.GetAxisRaw("Horizontal");

        // Зчитуємо введення по вертикалі (W/S, стрілки вгору/вниз)
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Рухаємо персонажа
        // .normalized гарантує, що рух по діагоналі не буде швидшим, ніж по прямій
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}