using System.Collections;
using UnityEngine;

public class Dog : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider;

    public GameObject player;
    public GameManager gameManager;

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
    public Sprite[] dirtySprites;

    public int dogStatus;  // 0 - Calm,  1 - Angry,  2 - Dirty
    

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
         ChangeDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dogStatus = 2;
        Destroy(collision.gameObject);
        gameManager.bombActive();        
        StartCoroutine(WaitDirty());
        
    }

    private void Move()
    {
        if (dogStatus == 1)
        {
            speed = 0.018f;
        }
        else
            speed = 0.009f;


        transform.Translate(speed * direction, Space.World);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle >= 45 && angle < 135)
        {
            if (dogStatus == 1)
                spriteRenderer.sprite = angrySprites[3];
            else if (dogStatus == 2)
                spriteRenderer.sprite = dirtySprites[3];
            else
                spriteRenderer.sprite = dogTop;
                        
        }

        else if (angle >= 135 || angle < -135)
        {
                   
            if (dogStatus == 1)
                spriteRenderer.sprite = angrySprites[1];
            else if (dogStatus == 2)
                spriteRenderer.sprite = dirtySprites[1];
            else
                spriteRenderer.sprite = dogLeft;
        }

        else if (angle > -135 && angle < -45)
        {
               
            if (dogStatus == 1)
                spriteRenderer.sprite = angrySprites[2];
            else if (dogStatus == 2)
                spriteRenderer.sprite = dirtySprites[2];
            else
                spriteRenderer.sprite = dogBottom;
        }
        else
        {
            if (dogStatus == 1)
                spriteRenderer.sprite = angrySprites[0];
            else if (dogStatus == 2)
                spriteRenderer.sprite = dirtySprites[0];
            else
                spriteRenderer.sprite = dogRight;
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
        
        if (dogStatus == 0 || dogStatus == 2)
        {
            direction.x = Random.Range(-8, 8);
            direction.y = Random.Range(-8, 8);
        }
        
    }

    private void isPigNear()
    {
       
        if(mydist < pigDist && dogStatus != 2)
        {
            dogStatus = 1;
        
        }
        else if(mydist > pigDist && dogStatus != 2)
        {
            dogStatus = 0;
        }
    }

    IEnumerator WaitDirty() {
        yield return new WaitForSeconds(5f); dogStatus = 0; }

}

