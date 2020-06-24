using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // 武器使用者
    public GameObject master { set; get; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.GetComponent<bullet>() != null) {
            Destroy(gameObject);
        }
        
        if (master != collider.gameObject) 
        {
            if (collider.gameObject.name == "主角1") {
                collider.gameObject.GetComponent<leadingRole>().changeHealth(1);
                Destroy(gameObject);
            }
            if (collider.gameObject.GetComponent<enermy>() != null)
            {
                collider.gameObject.GetComponent<enermy>().changeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
