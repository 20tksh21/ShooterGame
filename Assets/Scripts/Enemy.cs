using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private int currentHp;
    [SerializeField] private TextMeshProUGUI hpText;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;        //負荷軽減のためRigidbodyを使わずそのままtransformを動かす
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftWall"))
        {
            Destroy(gameObject);
        }
    }

    public void SetHp(int hp)
    {
        currentHp = hp;
        hpText.text = currentHp.ToString();
    }


    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        hpText.text = currentHp.ToString();
        if(currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
