using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject focalPoint;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        //Debug.Log(focalPoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(focalPoint.transform.position);
        float moveVertical = Input.GetAxis("Vertical");

        rb.AddForce(focalPoint.transform.forward * moveVertical * speed);
    }
}
