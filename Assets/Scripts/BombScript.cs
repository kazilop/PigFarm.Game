using UnityEngine;

public class BombScript : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dog")
        Destroy(gameObject);
    }
}
