using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{
    public int id = 0;

    public Sprite sprite;
    // 该武器将发射的子弹集合
    public GameObject[] bullets;

    // 当前发射中的子弹，在集合中的下标
    private int currentBulletIndex = -1;
    // Start is called before the first frame update

    // 当前发射中的子弹
    private GameObject currentBullet;

    // 当前武器是否处于使用状态
    public bool isUsed = false;

    // 目标敌人
    private GameObject targetEnermy;

    // 武器在攻击时，初始所在位置
    private Vector2 initPosition;

    // 目标位置
    private Vector2 targetPosition;

    // 子弹移动速度
    public float speed = 30f;

    // 当前子弹所处位置
    // private Vector2 currentBulletPos = Vector2.zero;

    // 是否处于攻击状态
    private bool onAttack = false;

    // 使用武器的对象
    private GameObject master;

    // 面朝方向
    private Vector2 faceDir;

    // 当前武器攻击一次消耗的蓝量
    public int cost = 1;

    public weapon(int id) {
        this.id = id;
    }
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (onAttack) {
            

            if (currentBullet == null)
            {
                changeBulletIndex();
                if (currentBulletIndex >= 0)
                {
                    GameObject bullet = bullets[currentBulletIndex];
                    currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                    currentBullet.GetComponent<bullet>().master = master;
                }
                else {
                    onAttack = false;
                    return;
                }
            }
            float length = (targetPosition - initPosition).magnitude;
            Rigidbody2D cb =  currentBullet.GetComponent<Rigidbody2D>();
            /*if (currentBulletPos == Vector2.zero)
            {
                currentBulletPos = initPosition;
            }
            else {
                currentBulletPos = Vector2.MoveTowards(currentBulletPos, targetPosition, 1f);
            }*/
            //currentBullet.GetComponent<Rigidbody2D>().MovePosition(currentBulletPos);
            if (this.targetEnermy == null)
            {
                currentBullet.transform.Translate(this.faceDir * Time.deltaTime * speed);
            }
            else {
                currentBullet.transform.Translate((targetPosition - (Vector2)transform.position).normalized * Time.deltaTime * speed);
            }
            float mag = ((Vector2)currentBullet.transform.position - initPosition).magnitude;
            if (mag > 20) {
                // currentBulletPos = Vector2.zero;
                Destroy(currentBullet);
                initPosition = transform.position;
            }
            
            
            
        }
    }

    public void changeBulletIndex() {
        
        if (currentBulletIndex < bullets.Length - 1)
        {
            currentBulletIndex = currentBulletIndex + 1;
        }
        else
        {
            currentBulletIndex = -1;
        }
    }
    public void attack(GameObject master, GameObject targetEnermy, Vector2 faceDir) {
        this.master = master;
        onAttack = true;
        this.targetEnermy = targetEnermy;
        if (targetEnermy != null) {
            targetPosition = targetEnermy.transform.position;
        }
        initPosition = transform.position;
        this.faceDir = faceDir;
    }

    public Sprite getSprite() {
        return this.sprite;
    }
}
