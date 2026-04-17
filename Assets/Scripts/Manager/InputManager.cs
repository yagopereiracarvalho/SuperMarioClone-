using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
 [SerializeField] bool jumpPressed;
 [SerializeField] bool jumpReleased;
 [SerializeField] bool isJumping;
    Vector2 movementInput;

    public static InputManager Instance;
    
    public bool JumpPressed { get => jumpPressed; set => jumpPressed = value;}
      public bool JumpReleased { get =>jumpReleased ; set =>  jumpReleased= value;}
      public bool IsJumping { get => isJumping ; set =>  isJumping= value;}

    void  Awake() 
    {
        Instance = this;   
    }
    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && !isJumping)
        {
            JumpPressed = true;
            JumpReleased = false;
            
        }
        else
        {
            JumpReleased = true;
        }
    }
    
    public static Vector2 GetMovementInput()
    {
        return Instance.movementInput;
    }

}
