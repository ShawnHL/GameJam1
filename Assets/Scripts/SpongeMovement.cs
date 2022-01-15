using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpongeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0.1f;
    private int torque = 3;
    [SerializeField]
    private float maxSpeed = 7f;
    [SerializeField]
    Rigidbody rbody;
    [SerializeField]
    Renderer renderer;

    private int tilesCleaned = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (rbody.velocity.magnitude > maxSpeed) {
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 direction = new Vector3(-1.0f, 0, 0);
            rbody.velocity += direction * speed;
            float turn = Input.GetAxis("Horizontal");
            rbody.AddTorque(transform.up * turn * torque);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            Vector3 direction = new Vector3(1.0f, 0, 0);
            rbody.velocity += direction * speed;
            float turn = Input.GetAxis("Horizontal");
            rbody.AddTorque(transform.up * turn * torque);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 direction = new Vector3(0, 0, 1.0f);
            rbody.velocity += direction * speed;
            float turn = Input.GetAxis("Vertical");
            rbody.AddTorque(transform.up * turn * torque);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 direction = new Vector3(0, 0, -1.0f);
            rbody.velocity += direction * speed;
            float turn = Input.GetAxis("Vertical");
            rbody.AddTorque(transform.up * turn * torque);
        }

        if (tilesCleaned == 3) {
            renderer.material.color = Color.green;
        }

    }
    void OnTriggerEnter(Collider c) {
        Debug.Log("collision\n");
        if (c.gameObject.tag == "Sticky") {
            Debug.Log("sticky collision\n");
            maxSpeed = 4f;
        }
        if (c.gameObject.tag == "Tile") {
            tilesCleaned += 1;
            Debug.Log("tiles cleaned: " + tilesCleaned.ToString());
        }
    }
    void OnTriggerExit(Collider c) {
        Debug.Log("collision exit\n");
        if (c.gameObject.tag == "Sticky") {
            maxSpeed = 10f;
        }
    }
}
