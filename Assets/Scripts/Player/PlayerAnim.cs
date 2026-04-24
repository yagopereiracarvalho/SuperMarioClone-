using UnityEngine;
public class PlayerAnim : MonoBehaviour
{
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       ChangeAnimation(); 
    }
    
    void ChangeAnimation()
    {
        if (InputManager.instance.IsJumping)
        {
            anim.SetInteger("Transition", 2);
        }
        else
        {
            if (InputManager.GetMovementInput().x == 0)
            {
                anim.SetInteger("Transition", 0);
            }
            else
            {
                 anim.SetInteger("Transition", 1);
            }
        }
    }
    
}
