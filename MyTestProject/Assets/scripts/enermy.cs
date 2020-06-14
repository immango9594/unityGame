using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermy : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;

    public int speed = 4;
    // Start is called before the first frame update

    public float time = 2;

    private float randomX = 0f;

    private float randomY = 0f;
    void Start()
    {
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (time <= 0) {
            time = 2;
            randomX = Random.Range(-1f, 1f);
            randomY = Random.Range(-1f, 1f);
        }
        Vector2 move = new Vector2(randomX, randomY);
        Vector2 position = transform.position;
        position = position + move * speed * Time.deltaTime;
        rigidBody2d.MovePosition(position);
        
        time -= Time.deltaTime;
    }
}
