using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float rotateSpeed = 10f;
    void Start()
    {
        
    }

    void Update()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");      //GetAxis→滑らか入力
        if(scroll != 0f)
        {
            float rotationAmount = scroll * rotateSpeed;
            transform.Rotate(0, 0, rotationAmount);     //軸はZ
        }

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
