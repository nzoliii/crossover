using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private bool isMoving = false;

    public LayerMask obstacleLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = rb.position;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.position = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);

            if (Vector2.Distance(rb.position, targetPosition) < 0.01f)
            {
                rb.position = targetPosition;
                isMoving = false;
            }
        }
    }

    public void Move(Vector2 direction)
    {
        if (isMoving) return;

        Vector2 newPosition = rb.position + direction;

        if (!IsBlocked(newPosition))
        {
            targetPosition = newPosition;
            isMoving = true;
        }
        else
        {
            Debug.Log("Movement blocked.");
        }
    }

    private bool IsBlocked(Vector2 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, 0.1f, obstacleLayer);
        return hit != null;
    }

    public void MoveUp() { Move(Vector2.up); }
    public void MoveDown() { Move(Vector2.down); }
    public void MoveLeft() { Move(Vector2.left); }
    public void MoveRight() { Move(Vector2.right); }
}
