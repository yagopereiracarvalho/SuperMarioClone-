using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("movimento")]
    [SerializeField] float moveSpeed;
    [SerializeField] float direction;

    [Header("Pulo")]
    [SerializeField] float jumpForce = 13;
    [SerializeField] float jumpingCutMultiplier = 0.05f;

    Rigidbody2D rig;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     rig = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
        Jump();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rig.linearVelocity = new Vector2(direction * moveSpeed, rig.linearVelocity.y);
    }
    void GetDirection()
    {
        direction = InputManager.GetMovementInput().x;

        if(direction > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(direction < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
    void Jump()
    {
        if (InputManager.Instance.JumpPressed)
        {
            rig.linearVelocity = new Vector2(rig.linearVelocity.x,jumpForce);
            
            InputManager.Instance.JumpReleased = false;
            InputManager.Instance.JumpPressed = false;
        }
        if (InputManager.Instance.JumpReleased)
        {
            if (rig.linearVelocity.y > 0)
            {
                rig.linearVelocity = new Vector2(rig.linearVelocity.x,rig.linearVelocity.y * jumpingCutMultiplier);
            }
            InputManager.Instance.JumpReleased = false;
        }
    }
}
