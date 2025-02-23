using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] private Rigidbody rb;
    public bool playerOnGround = true;

    public void MovePlayer(Vector2 input){
        Vector3 inputXYZ = new(input.x,0,input.y);
        rb.AddForce(inputXYZ * speed);
    }

    void OnCollisionStay(Collision collision)
    {
        playerOnGround = true;
    }

    void Update()
    {
         if(Input.GetKey(KeyCode.Space) && playerOnGround){
            rb.AddForce(new Vector3(0,8,0), ForceMode.Impulse);
            playerOnGround = false;
        }
    }

}
