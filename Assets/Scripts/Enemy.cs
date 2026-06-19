using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftWall"))
        {
            Destroy(gameObject);
        }
    }

}
