using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    [SerializeField] private Rigidbody rb; 

    // Update is called once per frame
    void Update()
    {
        Vector2 input = Vector2.zero;

        if(Input.GetKey(KeyCode.A)){
            input += Vector2.left;
        }
        if(Input.GetKey(KeyCode.D)){
            input += Vector2.right;
        }

        if(Input.GetKey(KeyCode.W)){
            input += Vector2.up;
        }

        if(Input.GetKey(KeyCode.S)){
            input += Vector2.down;
        }

        OnMove?.Invoke(input);

    }
}
