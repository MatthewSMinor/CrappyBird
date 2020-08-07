using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float horizontalSpeed = 5f;
    public float jumpSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            rb.velocity = new Vector2(jumpSpeed/3, jumpSpeed);
        }
    }

    private void FixedUpdate() {

        rb.AddForce(transform.right * horizontalSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
        Application.LoadLevel(Application.loadedLevel);
    }
}
