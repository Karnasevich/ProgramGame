using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // 1. Рух (WASD або стрілки)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveX, moveY, 0).normalized;

        // Рухаємо у світових координатах, щоб обертання не впливало на WASD
        transform.position += movement * speed * Time.deltaTime;

        // 2. Обмеження екрана
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // 3. Обертання до курсора миші
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Віднімаємо 90 градусів, якщо "ніс" твоєї моделі дивиться вгору (по осі Y)
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
    }
}