using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;
    public CharacterController Controller;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private Transform CeilingCheck;

    [SerializeField] private LayerMask Ground;

    private float LastGrounded = Mathf.NegativeInfinity;

    [SerializeField] private float CoyoteTime = 0.02f;
    [SerializeField] private float Gravity = 10f;
    [SerializeField] private float JumpSpeed = 10f;

    private Vector3 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.up);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(GroundCheck.position, Controller.radius, Ground))
        {
            LastGrounded = Time.time;
            Velocity.y = Mathf.Max(Velocity.y, -1f);
        }
        else if (Physics.CheckSphere(CeilingCheck.position, Controller.radius, Ground))
        {
            Velocity.y = Mathf.Min(Velocity.y, 0f);
        }
        Velocity.y -= Time.deltaTime * Gravity;
        

        if (Input.GetButton("Jump") && LastGrounded + CoyoteTime >= Time.time)
        {
            Velocity.y = JumpSpeed;
            LastGrounded = Mathf.NegativeInfinity;
        }

        Vector3 moveAxis = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        moveAxis.Normalize();

        Controller.Move(Speed * Time.deltaTime * moveAxis);
        Controller.Move(Time.deltaTime * Velocity);

        if (transform.position.y < -10f)
        {
            transform.position = Vector3.up * 10f;
        }
    }
}
