using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite pigLeft;
    public Sprite pigRight;
    public Sprite pigTop;
    public Sprite pigBottom;

    [SerializeField]
    private Joystick joy;

    float speed = 4.0f;

    public string joyspd;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = pigLeft;
    }


    void Update()
    {

        JoystickFun();
        
    }

    private void FixedUpdate()
    {
        PigCorrection();
    }

    void JoystickFun()
    {
        if (joy.speed > 0.0f)
        {
            Vector2 direction = joy.direction;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.Translate(direction * speed * joy.speed * Time.deltaTime, Space.World);

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

            joyspd = angle.ToString();
        }
    }

    void PigCorrection()
    {
        Vector3 currentPos = transform.position;

        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (currentPos.y > 3.7f)
        {
            currentPos.y = 3.7f;        
        }
        if (currentPos.y < -4.2f)
        {
            currentPos.y = -4.2f;
        }
        if(currentPos.x > (currentPos.y - 68)/8 + 17)
        {
            currentPos.x = (currentPos.y - 68)/8 + 17;
        }
        if(currentPos.x < (1.5 * currentPos.y - 71.1)/ 7.9 )
        {
            currentPos.x = (float)((1.5 * currentPos.y - 71.1) / 7.9 );
        }


        transform.position = currentPos;

    }
}
