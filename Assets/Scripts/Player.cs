using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Sprite pigLeft;
    public Sprite pigRight;
    public Sprite pigTop;
    public Sprite pigBottom;

    [SerializeField]
    private Joystick joy;

    float speed = 10.0f;

    public string joyspd;

    private float _angleOffset = 90f;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(joy.speed > 0.0f)
        {
            Vector2 direction = joy.direction;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle + _angleOffset);
            transform.Translate(direction * speed * joy.speed * Time.deltaTime, Space.World);

            joyspd = direction.y.ToString();

        }

    }
}
