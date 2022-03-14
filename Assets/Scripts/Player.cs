using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
   // public Sprite sprite;
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
            else  //(angle >= -45 || angle < 45)
                spriteRenderer.sprite = pigRight;

            joyspd = angle.ToString();
        }

        

    }
}
