using UnityEngine;

public class Dog : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider;

    public GameObject player;

    [SerializeField]
    private float mydist;

    private Vector3 direction;
    private float pigDist = 3.0f;
    private float speed = 0.009f;

    private SpriteRenderer spriteRenderer;
    public Sprite dogLeft;
    public Sprite dogRight;
    public Sprite dogTop;
    public Sprite dogBottom;

    public Sprite[] angrySprites;

    public int dogStatus;  // 0 - Calm,  1 - Angry,  2 - Filthy


    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = dogRight;

        dogStatus = 0;

        ChangeDirection();
    }


    void FixedUpdate()
    {
        Move();
        dogCorrection();
        isPigNear();

        if (dogStatus == 1)
        {
            direction = player.transform.position - transform.position;
        }

        mydist = (player.transform.position - transform.position).magnitude;
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
            if (dogStatus == 0)
                spriteRenderer.sprite = dogTop;
            else if (dogStatus == 1)
                spriteRenderer.sprite = angrySprites[3];
        }

        else if (angle >= 135 || angle < -135)
        {
            if (dogStatus == 0)
                spriteRenderer.sprite = dogLeft;
            else if (dogStatus == 1)
                spriteRenderer.sprite = angrySprites[1];
        }

        else if (angle > -135 && angle < -45)
        {
            if (dogStatus == 0)
                spriteRenderer.sprite = dogBottom;
            else if (dogStatus == 1)
                spriteRenderer.sprite = angrySprites[2];
        }
        else
        {
            if (dogStatus == 0)
                spriteRenderer.sprite = dogRight;
            else if (dogStatus == 1)
                spriteRenderer.sprite = angrySprites[0];
        }
    }

    void dogCorrection()
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
        
        if (dogStatus == 0)
        {
            direction.x = Random.Range(-8, 8);
            direction.y = Random.Range(-8, 8);
        }
        
    }

    private void isPigNear()
    {
       
        if(mydist < pigDist)
        {
            dogStatus = 1;
        
        }
        else if(mydist > pigDist)
        {
            dogStatus = 0;
        }
    }

}

