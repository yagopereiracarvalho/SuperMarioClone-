using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] bool isPaused;
    [Header("player")]
    [SerializeField] int lifes = 3;
    [SerializeField] PlayerAnim playerAnim;
    [SerializeField] float changeTIme;
    [SerializeField] bool isGrowUp;
    [SerializeField] bool isFlower;

    [Header("Star Mode")]
    [SerializeField] bool isStarman;
     [SerializeField] float starmanTime;
     [SerializeField] Color[] starMode;
     [SerializeField] CapsuleCollider2D starManLittleCollider;
      [SerializeField] CapsuleCollider2D starManBigCollider; 
     
    public static GameController instance;

    public bool IsPaused { get  => isPaused;set => isPaused = value; }
    public bool IsGrowUp { get => isGrowUp; set => isGrowUp = value; }
    public bool IsFlower {get => isFlower; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }
    public void GrowUp()
    {
        isGrowUp = true; 
        StartCoroutine(ChangePlayer(0,1));
    }

    public void Flower()
    {
        if (isGrowUp)
        {
            StartCoroutine(ChangePlayer(1, 2));
        }
        else
        {
            StartCoroutine(ChangePlayer(0, 2));
        }
        isGrowUp = true;
        isFlower = true; 
    }
    public void GetLife()
    {
        lifes++;
    }
    IEnumerator  ChangePlayer(int actualplayer,int nextPlayer)
    {
        isPaused = true;
        playerAnim.LayerWeight = nextPlayer;
        yield return new WaitForSeconds(changeTIme);
         playerAnim.LayerWeight = actualplayer;
        yield return new WaitForSeconds(changeTIme);
         playerAnim.LayerWeight = nextPlayer;
        yield return new WaitForSeconds(changeTIme);
         playerAnim.LayerWeight = actualplayer;
        yield return new WaitForSeconds(changeTIme);
         playerAnim.LayerWeight = nextPlayer;
         isPaused = false;
    }
    public IEnumerator StarMode()
    {
        if(isStarman) yield break; 
        isStarman = true;

        if (isGrowUp)
        {
            starManBigCollider.enabled = true;
        }
        else
        {
            starManLittleCollider.enabled = true;
        }

        yield return new WaitForSeconds(0.1f);
        for(int j = 0; j < 25; j++)
        {
            for(int i = 0; i < starMode.Length; i++)
            {
                playerAnim.GetComponent<SpriteRenderer>(). color = starMode[i];
                yield return new WaitForSeconds(starmanTime);
            }
        }
        yield return new WaitForSeconds(0.1f);
        for(int i = 0 ; i < starMode.Length; i++)
        {
            playerAnim.GetComponent<SpriteRenderer>(). color = starMode[i];
                yield return new WaitForSeconds(starmanTime);
        }
        isStarman = false; 

        starManBigCollider.enabled = false;
        starManLittleCollider.enabled = false;

        playerAnim.GetComponent <SpriteRenderer> ().color = Color.white; 
    }
}
