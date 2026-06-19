using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("RightWall"))
        {
            Destroy(gameObject);
        }

        //敵と当たったら敵も自分も消す
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
