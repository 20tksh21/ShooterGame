using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private float rotateSpeed = 10f;

    public int currentAtk { get; set; } = 1;

    private UpgradeData upgradeData;

    void Update()
    {
        if (Time.timeScale == 0f) return;

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
         Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
         bullet.Atk = currentAtk;

    }

    public void ApplyUpgrade(UpgradeData data)
    {
        switch (data.upgradeType)
        {
            case UpgradeType.AtkUp:
                currentAtk += data.value;
                return;
        }
    }
}
