using UnityEngine;

public class PigScript : MonoBehaviour
{
    
    CapsuleCollider2D capsuleCollider;

    private Vector3 direction;
    private float speed = 0.002f;

    private SpriteRenderer spriteRenderer;
    public Sprite pigLeft;
    public Sprite pigRight;
    public Sprite pigTop;
    public Sprite pigBottom;


    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = pigRight;

        ChangeDirection();
    }

    
    void FixedUpdate()
    {
        Move();
        PigCorrection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (capsuleCollider != null)
        {
            ChangeDirection();
        }
    }

    private void Move()
    {
        transform.Translate(speed * direction, Space.World);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle >= 45 && angle < 135)
        {
            spriteRenderer.sprite = pigTop;
        }

        else if (angle >= 135 || angle < -135)
        {
            spriteRenderer.sprite = pigLeft;
        }

        else if (angle > -135 && angle < -45)
        {
            spriteRenderer.sprite = pigBottom;
        }
        else
            spriteRenderer.sprite = pigRight;

    }

    void PigCorrection()
    {
        Vector3 currentPos = transform.position;

        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (currentPos.y > 3.7f)
        {
            currentPos.y = 3.7f;
            ChangeDirection();
            transform.position = currentPos;
        }
        if (currentPos.y < -4.2f)
        {
            currentPos.y = -4.2f;
            ChangeDirection();
            transform.position = currentPos;
        }
        if (currentPos.x > (currentPos.y - 68) / 8 + 17)
        {
            currentPos.x = (currentPos.y - 68) / 8 + 17;
            ChangeDirection();
            transform.position = currentPos;
        }
        if (currentPos.x < (1.5 * currentPos.y - 71.1) / 7.9)
        {
            currentPos.x = (float)((1.5 * currentPos.y - 71.1) / 7.9);
            ChangeDirection();
            transform.position = currentPos;
        }


        
    }

    private void ChangeDirection()
    {
        direction.x = Random.Range(-8, 8);
        direction.y = Random.Range(-8, 8);
    }

}
