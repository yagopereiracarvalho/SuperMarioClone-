using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{
    [SerializeField] float StartPos; 
    float posY;
    protected float direction;
    protected bool isStarted; 
    CapsuleCollider2D capsuleCollider;
    public float Direction {get => direction; set => direction = value;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetValues(); 
    }

    // Update is called once per frame
    void Update()
    {
        Started(); 
    }
    protected void Started()
    {
        if(transform.position.y < posY && !isStarted)
        {
         transform.Translate(Vector3.up *Time.deltaTime);
        }
        else
        {
            capsuleCollider.enabled = true; 
            isStarted = true;
        }
    }
    protected void SetValues()
    {
        posY = transform.position.y + StartPos;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        capsuleCollider.enabled = false; 
    }
}
