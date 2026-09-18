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
}
