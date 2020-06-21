using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    public float speed;
    public float jump;
    public Transform groundCheck;
   // public float rayCheckDistance;
    Rigidbody2D rb;

    public bool isGrounded = false;
    public float groundDistance = 0.0001f;

    public LayerMask groundChecks;

    public GameOver go;

    public Text interactText;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(groundCheck.position, 0.01f);

    }

        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
            go.StartSequence(false);

        if (Input.GetKeyDown("m"))
            SceneManager.LoadScene("Menu");

        if (canMove) {
            //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundChecks);
            //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundChecks);
            isGrounded = Physics2D.OverlapPoint(groundCheck.position, groundChecks);


            float x = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown("w") && isGrounded)
            {
                rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            }
            rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Danger")
            go.StartSequence(false);

        if (!canMove)
            return;
        if(collision.tag == "Lever")
        {
            interactText.text = "Press F to interact";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {  
        if (collision.tag == "Lever")
        {
            interactText.text = "";
        }
    }
}