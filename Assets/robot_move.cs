using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private bool isGrounded;


    public int lives = 1;  // Player starts with 1 life

    public Transform groundCheck;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ensure gravity is enabled for jumping
        rb.gravityScale = 2;
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);

        if (moveInput.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput.x < 0 && facingRight)
        {
            Flip();
        }

        // Jumping logic
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        //{
        //    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        //    Debug.Log("Jump Pressed!");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        Debug.Log("Is Grounded: " + isGrounded);

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    // Collision Handling

    void OnTriggerEnter2D(Collider2D other)
    {
        // Battery Collisiob
        if (other.CompareTag("Battery"))
        {
            lives++; 
            Destroy(other.gameObject); 
            Debug.Log("Extra life gained! Lives: " + lives);
        }

        // Bomb Collision
        else if (other.CompareTag("Bomb"))
        {
            if (lives > 1)
            {
                lives--;
                Destroy(other.gameObject);
                Debug.Log("Hit by bomb! Lives left: " + lives);
            }
            else
            {
                Destroy(gameObject); // Player dies
                Debug.Log("Game Over!");
            }
        }
    }



}

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Bomb"))
//        {
//            if (lives > 1)
//            {
//                lives--;
//                Destroy(other.gameObject);  // Remove bomb
//            }
//            else
//            {
//                Destroy(gameObject);  // Player dies
//                Debug.Log("Game Over!");
//            }
//        }
//        else if (other.CompareTag("Battery"))
//        {
//            lives++;
//            Destroy(other.gameObject);  // Remove battery
//            Debug.Log("Extra life gained! Lives: " + lives);
//        }
//    }
//}



//using UnityEditor.Experimental.GraphView;
//using UnityEngine;

//public class robot_move : MonoBehaviour
//{
//    public float speed = 5f;
//    private Rigidbody2D rb;
//    private Vector2 moveInput;
//    private int lives = 1;



//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();

//    }

//  void OnTriggerEnter2D(Collider2D other) //include player dead within the movement as a test
//    {
//        if (other.CompareTag("Bomb"))
//        {
//            if(lives > 1)
//            {
//                lives--;
//            }

//            Destroy(other.gameObject);
//        }
//            else
//            {
//            Destroy(gameObject);
//            }
//    else if(other.CompareTag("Battery"))
//       {
//            lives++;
//            Destroy(other.gameObject);

//        }

//    }


//    // Update is called once per frame
//    void Update()
//    {
//        moveInput.x = Input.GetAxis("Horizontal"); //moving left to right
//        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
//    }


//}
