using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leadingRole : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;

    public int speed = 4;

    private Transform[] weapons;

    private int currentWeaponIndex = 0;

    private GameObject targetEnermy;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        weapons = gameObject.GetComponentsInChildren<Transform>();
        int i = transform.GetSiblingIndex();
        //GameObject go = GameObject.Find("/qs");
        GameObject go = GameObject.Find("/enermy");
        Transform[] trans = go.GetComponentsInChildren<Transform>();
        targetEnermy = trans[1].gameObject;
        Debug.Log(targetEnermy.name);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);
        Vector2 position = transform.position;
        position = position + move * speed * Time.deltaTime;
        rigidBody2d.MovePosition(position);
        //Debug.Log(weapons[currentWeaponIndex + 1]);
        foreach (Transform t in weapons) {
           
           /* if (t.gameObject.name == "weapon" && (t.gameObject.GetComponent<weapon>().isUsed)) {
                weapon w = t.gameObject.GetComponent<weapon>();
                Vector2 targetPosition = targetEnermy.transform.position;
                w.
            }*/
        }
        bool h = Input.GetKeyDown("h");
        if (h) {
            weapons[currentWeaponIndex + 1].GetComponent<weapon>().attack(new Vector2(1000, 0), targetEnermy);
        }
        //gun.transform.position = position - new Vector2(0.5f, -0.5f);
    }
}
