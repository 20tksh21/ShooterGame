using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;


    public int Atk { get; set; } = 1;

    void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //右の壁に当たった時の処理
        if(collision.CompareTag("RightWall"))
        {
            Destroy(gameObject);
        }


        //敵に当たった時の処理
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(Atk);
                GameManager.Instance.AddScore(Atk);
            }

            Destroy(gameObject);
        }
    }
}
