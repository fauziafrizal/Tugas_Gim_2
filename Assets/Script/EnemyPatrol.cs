using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform leftPoint;
    public Transform rightPoint;

    private int direction = 1; // 1 = kanan, -1 = kiri

    void Start()
    {
        if (leftPoint != null && rightPoint != null && leftPoint.position.x > rightPoint.position.x)
        {
            Transform temp = leftPoint;
            leftPoint = rightPoint;
            rightPoint = temp;
        }
    }

    void Update()
    {
        if (leftPoint == null || rightPoint == null)
            return;

        float moveAmount = direction * speed * Time.deltaTime;
        transform.position += new Vector3(moveAmount, 0f, 0f);

        if (direction == 1 && transform.position.x >= rightPoint.position.x)
        {
            transform.position = new Vector3(rightPoint.position.x, transform.position.y, transform.position.z);
            direction = -1;
        }
        else if (direction == -1 && transform.position.x <= leftPoint.position.x)
        {
            transform.position = new Vector3(leftPoint.position.x, transform.position.y, transform.position.z);
            direction = 1;
        }
    }
}