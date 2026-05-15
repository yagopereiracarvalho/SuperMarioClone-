using UnityEngine;
public class PlayerAnim : MonoBehaviour
{
    [SerializeField] int layerWeight;
    Animator anim;

    public int LayerWeight {get => layerWeight;  set => layerWeight = value;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       ChangeAnimation(); 
       changelayer();
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

    void changelayer()
    {
        if(layerWeight == 0)
        {
            anim.SetLayerWeight(1,0);
            anim.SetLayerWeight(2,0);
        }
        else if(layerWeight == 1)
        {
            anim.SetLayerWeight(1,1);
            anim.SetLayerWeight(2,0);
        }
        else if(layerWeight == 2)
        {
             anim.SetLayerWeight(1,0);
            anim.SetLayerWeight(2,1);
        }
    }
    
}
