using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

[Header("movimento")]
[SerializeField] float moveSpeed;
[SerializeField] float direction;

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
}
