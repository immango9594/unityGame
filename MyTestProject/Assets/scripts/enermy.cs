using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermy : MonoBehaviour
{
    // 敌人刚体
    private Rigidbody2D rigidBody2d;

    // 敌人移动速度
    public int speed = 4;
    // Start is called before the first frame update

    // 敌人随机切换移动方向的周期
    public float time = 2;

    // 随机移动X轴系数
    private float randomX = 0f;

    // 随机移动Y轴系数
    private float randomY = 0f;

    // 当前血量
    private int currentHealth = 5;

    private GameObject leadingRole;

    private weapon currentWeapon;

    private Vector2 faceDir = new Vector2(1, 0);
    // 最大血量
    public int maxHealth { set; get; } = 5;
    void Start()
    {
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        leadingRole = transform.Find("/主角1").gameObject;
        currentWeapon = gameObject.GetComponentInChildren<weapon>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(randomX, randomY);
        if (move != Vector2.zero)
        {
            faceDir = move.normalized;
        }
        if (time <= 0) {
            time = 2;
            randomX = Random.Range(-1f, 1f);
            randomY = Random.Range(-1f, 1f);
            currentWeapon.attack(gameObject, leadingRole, this.faceDir);
        }
        Vector2 position = transform.position;
        position = position + move * speed * Time.deltaTime;
        rigidBody2d.MovePosition(position);
        
        time -= Time.deltaTime;
    }

    public void changeHealth(int damageNum) {
        float percent = (float)(currentHealth - damageNum) / (float)maxHealth;
        this.GetComponentInChildren<Canvas>().GetComponent<HealthLittle>().setWidth(percent);
        currentHealth = currentHealth - damageNum;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
