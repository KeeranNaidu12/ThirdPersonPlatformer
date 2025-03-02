using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] private int maxJump = 2;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private int jumpCount = 0;

    private float gravity = -10;
    public bool playerOnGround = true;


    void Start()
    {
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        if(!playerOnGround){
            rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")){
        playerOnGround = true;
        jumpCount = 0;
        }
    }
    

 void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        playerOnGround = false;

    }
    void Update()
    {
    float verticalMotion = Input.GetAxis("Vertical");
    float horizontalMotion = Input.GetAxis("Horizontal");

    Vector3 moveForward = Camera.main.transform.forward * verticalMotion * speed;
    Vector3 moveSide = Camera.main.transform.right * horizontalMotion * speed;

       Vector3 inputXYZ = (moveForward + moveSide).normalized;
       inputXYZ.y = 0;
        rb.AddForce(inputXYZ * speed);
         if(Input.GetKeyDown(KeyCode.Space) && (jumpCount < maxJump || playerOnGround)){
            rb.linearVelocity = new Vector3(rb.linearVelocity.x,8,rb.linearVelocity.z);
            jumpCount++;
            playerOnGround = false;
        }  
    }

}
