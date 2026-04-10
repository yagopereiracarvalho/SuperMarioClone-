using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    Vector2 movementInput;

    public static InputManager Instance;

void  Awake() 
{
    Instance = this;   
}
void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
    public static Vector2 GetMovementInput()
    {
        return Instance.movementInput;
    }

}
