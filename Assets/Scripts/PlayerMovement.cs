
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(jumpSpeed/2, jumpSpeed);
        }
    }

    private void FixedUpdate() {

        rb.AddForce(transform.right * horizontalSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
        SceneManager.LoadScene("TitleScreen");
    }
}
