using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Joystick : MonoBehaviour
{
    public float speed = 0.0f;
    public float maxAlloedSize = 50.0f;

    [HideInInspector]
    public Vector2 direction = Vector2.zero;

    [SerializeField]
    private Sprite activeSprite;

    [SerializeField]
    private Sprite idleSprite;


    Vector2 startPosition = Vector2.zero;
    Vector2 position = Vector2.zero;

    Image img;

    RectTransform rectTransform;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }

    public void OnPointerDown(BaseEventData data)
    {
        PointerEventData pntr = (PointerEventData)data;
        startPosition = pntr.position;
        img.sprite = activeSprite;
    }

    public void OnDrag(BaseEventData data)
    {
        PointerEventData pntr = (PointerEventData)data;
        position = pntr.position - startPosition;
        float size = position.magnitude;

        if(size > maxAlloedSize)
        {
            speed = 1.0f;
            position = position / size * maxAlloedSize;
        }
        else
        {
            speed = size / maxAlloedSize;
        }

        direction = position / size;
        rectTransform.localPosition = position;
    }

    public void OnPointerUp(BaseEventData data)
    {
        speed = 0.0f;
        direction = Vector2.zero;
        rectTransform.localPosition = Vector3.zero;
        img.sprite = idleSprite;
    }
}
