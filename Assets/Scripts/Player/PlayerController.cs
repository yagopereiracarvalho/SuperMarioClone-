using System.Data.Common;
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
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject fireball;
    [SerializeField] float timeFire;
    float Fireinterval;
    float directionBall;
    Rigidbody2D rig;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     rig = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.instance.IsPaused)
        {
            rig.gravityScale = 3;
        GetDirection();
        Jump();
            if (GameController.instance.IsFlower)
            {
                Fire();
            }
            if(Fireinterval > 0)
            {
                Fireinterval -= Time.deltaTime;
            }
        }
        else
        {
            rig.gravityScale = 0;
            rig.linearVelocity = Vector2.zero;
        }
    }
    void FixedUpdate()
    {
   if(!GameController.instance.IsPaused)     Move();
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
            directionBall = 1;
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(direction < 0)
        {
            directionBall = -1;
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
    void Jump()
    {
        if (InputManager.instance.JumpPressed)
        {
            rig.linearVelocity = new Vector2(rig.linearVelocity.x,jumpForce);
            
            InputManager.instance.JumpReleased = false;
            InputManager.instance.JumpPressed = false;
        }
        if (InputManager.instance.JumpReleased)
        {
            if (rig.linearVelocity.y > 0)
            {
                rig.linearVelocity = new Vector2(rig.linearVelocity.x,rig.linearVelocity.y * jumpingCutMultiplier);
            }
            InputManager.instance.JumpReleased = false;
        }
    }

    void Fire()
    {
        if (InputManager.instance.IsFire && Fireinterval <= 0 )
        {
            Fireinterval = timeFire;
            InputManager.instance.IsFire = false; 
           GameObject fire =  Instantiate(fireball,firePoint.position, firePoint.rotation);
           fire.GetComponent<FireBall>().Direction = directionBall;
        }
    }
  
}
