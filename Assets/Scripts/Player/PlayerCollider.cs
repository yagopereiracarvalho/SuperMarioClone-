using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float radius = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       CheckedCollision(); 
    }
    void CheckedCollision ()
    {
         bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
         InputManager.Instance.IsJumping = !isGrounded;
         Debug.DrawRay(groundCheck.position, Vector2.down * radius, Color.red);
    }
}
