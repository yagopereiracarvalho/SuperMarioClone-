using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UIElements;

public class mushoroom : Item 
{
    [SerializeField] float speed;
    CircleCollider2D CircleCollider;
    Rigidbody2D rig; 
    [Header("Raycast Settings")]
    [SerializeField] float forwardRaylegth = 0.5f; 
    [SerializeField] LayerMask groundLayer; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetValues();
        CircleCollider = GetComponent<CircleCollider2D>();
        rig = GetComponent<Rigidbody2D>();
        CircleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Started();
        if (isStarted)
        {
            CircleCollider. enabled = true;
            rig.gravityScale = 3;
            Move();
            CheckRaycats(); 
            if(direction == 0)
            {
                direction = 1; 
            }        }
    }
    void Move()
    {
        rig.linearVelocity= new Vector2(speed * direction, rig.linearVelocity.y);
    }
 void CheckRaycats()
    {
        Vector2 forwardDir = direction > 0 ? Vector2.right : Vector2.left; 
        RaycastHit2D forwardHit = Physics2D.Raycast(transform.position, forwardDir, forwardRaylegth, groundLayer);
         if( forwardHit.collider != null)
        {
            direction *= -1;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Vector3 forwardDir = direction > 0 ? Vector2.right : Vector2. left;
        Gizmos.DrawLine(transform.position, transform.position + forwardDir * forwardRaylegth);
    }


}
