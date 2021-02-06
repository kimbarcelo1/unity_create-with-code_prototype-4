using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    public float speed;
    private float powerupStrength = 15.0f;
    public bool hasPowerup = false;

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

        // make the powerup indicator follow the play
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerups"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(hasPowerup);
            Destroy(other.gameObject);

            // gawin yung pag wait ng 7 seconds
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        // mag antay ng 7 seconds then set powerup to false after 7 seconds
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(hasPowerup);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Collided with " + collision.gameObject.name);

            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
