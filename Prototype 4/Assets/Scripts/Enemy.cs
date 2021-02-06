using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        //Debug.Log((player.transform.position - transform.position).magnitude); //7 ang magnitude
        //Debug.Log((player.transform.position - transform.position).normalized);
        //0 yung z axis ni player tapos 7 yung z ni enemy, ngayon sqaure root of z squared
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += player.transform.position * Time.deltaTime * 2;
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        rb.AddForce(lookDirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
