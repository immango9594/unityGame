using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class leadingRole : MonoBehaviour
{
    // 主角身上的刚体
    private Rigidbody2D rigidBody2d;

    // 主角的移动速度
    public int speed = 4;

    // 主角拥有的武器集合
    public GameObject[] weapons;

    // 当前使用中的武器，在集合中的下标
    private int currentWeaponIndex = 0;

    // 当前使用的武器
    private weapon currentWeapon;
    // 目标敌人
    private GameObject targetEnermy;

    // 主角当前生命值
    private int currentHealth = 5;

    private int currentMana = 100;

    private int maxMana = 100;

    private Vector2 faceDir = new Vector2(1, 0);
    // 主角最大生命值
    public int maxHealth { set; get; } = 5;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(transform.Find("/ItemList"));
        currentWeapon = weapons[currentWeaponIndex].GetComponent<weapon>();
        int i = transform.GetSiblingIndex();
        //GameObject go = GameObject.Find("/qs");
        setTargetEnermy();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);
        if (move != Vector2.zero) {
            faceDir = move.normalized;
        }
        Vector2 position = transform.position;
        position = position + move * speed * Time.deltaTime;
        rigidBody2d.MovePosition(position);
        bool h = Input.GetKeyDown("h");
        if (h) {
            changeManaPoint();
            if (targetEnermy == null || (targetEnermy.transform.position - transform.position).magnitude > 10)
            {
                GameObject go = GameObject.Find("/Enermy");
                Transform[] trans = go.GetComponentsInChildren<Transform>();
                if (trans != null && trans.Length > 0) { 
                    setTargetEnermy();
                }
            }
            Debug.Log("when press h:" + targetEnermy);
            currentWeapon.attack(gameObject, targetEnermy, faceDir);
            
        }
        bool k = Input.GetKeyDown("k");
        if (k)
        {
            /*GameObject pfb = Resources.Load("prefabs/1") as GameObject;
            GameObject prefabInstance = Instantiate(pfb);
            prefabInstance.transform.parent = transform;
            prefabInstance.AddComponent<weapon>();*/
            
            currentWeaponIndex = currentWeaponIndex + 1;
            if (currentWeaponIndex >= weapons.Length - 1) {
                currentWeaponIndex = 0;
            }
            currentWeapon = weapons[currentWeaponIndex].GetComponent<weapon>();
            transform.Find("/UsedWeapon").GetComponentInChildren<Image>().sprite = currentWeapon.getSprite();
        }
    }

    public void changeHealth(int damageNum) {
        float percent = (float)(currentHealth - damageNum) / (float)maxHealth;
        health.instance.setWidth(percent, "Red");
        this.GetComponentInChildren<Canvas>().GetComponent<HealthLittle>().setWidth(percent);
        currentHealth = currentHealth - damageNum;
        
    }
    public void changeManaPoint()
    {
        currentMana = currentMana - currentWeapon.cost;
        float manaPercent = (float)currentMana / (float)maxMana;
        health.instance.setWidth(manaPercent, "Blue");
    }
    private void setTargetEnermy() 
    {
        GameObject go = GameObject.Find("/Enermy");
        Transform[] trans = go.GetComponentsInChildren<Transform>();
        float minDistance = 0f;
        foreach (Transform t in trans) 
        {
            if (t.name == "Enermy") {
                continue;
            }
            float distance = (t.position - transform.position).magnitude;
            if (minDistance == 0f || distance < minDistance) 
            {
                minDistance = distance;
                targetEnermy = t.gameObject;
            }
        }
    }
}
