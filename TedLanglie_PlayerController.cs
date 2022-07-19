using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TedLanglie_PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallSpeed;
    LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ground = LayerMask.GetMask("Solid");
    }

    void Update()
    {
        PlayerJump();
        checkIsGrounded();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        PlayerSpeedFall();
    }

    void MovePlayer()
    {
        float horizMove = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector3(0f, rb.velocity.y, horizMove);
    }

    void PlayerSpeedFall()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallSpeed * Time.deltaTime;
        }
    }

    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    void checkIsGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.65f, ground, QueryTriggerInteraction.Ignore);
        
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
    }

    public void changeMoveSpeed(float changeAmount)
    {
        moveSpeed += changeAmount;
        if(moveSpeed < 0) moveSpeed+= (changeAmount*-1 + 1);
    }

    public void changeJumpForce(float changeAmount)
    {
        jumpForce += changeAmount;
        if(jumpForce < 0) jumpForce+= (changeAmount*-1 + 1);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
