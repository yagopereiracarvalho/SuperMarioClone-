using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Star : Item
{
    [SerializeField] float speed; 
    [SerializeField] float force; 
    CircleCollider2D circleCollider; 
    Rigidbody2D rig; 
    [Header("Raycast settings")]
    [SerializeField] float forwardRayLength = 0.4f;
    [SerializeField] float downRayLength = 0.4f; 
    [SerializeField] LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetValues(); 
        circleCollider = GetComponent<CircleCollider2D>();
        rig = GetComponent<Rigidbody2D>();
        circleCollider.enabled = false; 

    }

    // Update is called once per frame
    void Update()
    {
        Started();
        if (isStarted)
        {
            circleCollider.enabled = true; 
            rig.gravityScale = 3; 
            Move();
            CheckRaycasts();
            if (direction == 0)
            {
                direction= 1; 
            }
        }
    }
    void Move()
    {   
    rig.linearVelocity = new Vector2(Direction * speed, rig.linearVelocity.y);
    }
    void CheckRaycasts()
    {
        Vector2 forwardDir = direction > 0 ? Vector2.right : Vector2.left;
        RaycastHit2D forwardHit = Physics2D.Raycast(transform.position, forwardDir, forwardRayLength, groundLayer);
        if(forwardHit.collider != null)
        {
            direction *= -1;
        }
        RaycastHit2D downHit = Physics2D.Raycast(transform.position,Vector2.down, downRayLength, groundLayer);
        if (downHit.collider != null)
        {
            rig.linearVelocity = new Vector2(rig.linearVelocity.x, 0f);
            rig.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}
