using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject[] bullets;

    private Vector2 bulletForce;

    private int currentBulletIndex = -1;
    // Start is called before the first frame update

    private GameObject currentBullet;

    public bool isUsed = false;

    private GameObject targetEnermy;

    private Vector2 initPosition;

    private Vector2 targetPosition;

    private Vector2 currentForce = new Vector2(0, 0);
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBulletIndex >= 0) {
            GameObject bullet = bullets[currentBulletIndex];

            if (currentBullet == null)
            {
                currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            }
            float length = (targetPosition - initPosition).magnitude;
            float num = 100 / length;
            bulletForce = targetPosition * num;
            Debug.Log(targetPosition);
            Debug.Log(bulletForce);
            Rigidbody2D cb =  currentBullet.GetComponent<Rigidbody2D>();
            if (currentForce.x == 0 && currentForce.y == 0) {
                cb.AddForce(bulletForce);
            }
            
            Vector2 currentBulletPos = currentBullet.transform.position;
            float mag = (currentBulletPos - initPosition).magnitude;
            if (mag > 10)
            {

                Destroy(currentBullet);
                currentForce = new Vector2(0, 0);
                if (currentBulletIndex < 2)
                {
                    currentBulletIndex = currentBulletIndex + 1;
                }
                else
                {
                    currentBulletIndex = -1;
                }
            }
            
            
            
            
        }
    }

    public void attack(Vector2 force, GameObject targetEnermy) {
        //bulletForce = force;
        currentBulletIndex = 0;
        this.targetEnermy = targetEnermy;
        targetPosition = targetEnermy.transform.position;
        initPosition = transform.position;
    }
}
