using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] bool isPaused;
    [Header("player")]
    [SerializeField] PlayerAnim playerAnim;
    [SerializeField] float changeTIme;
    [SerializeField] bool isGrowUp;

    public static GameController instance;

    public bool IsPaused{ get  => isPaused;set => isPaused = value; }
    public bool IsGrowUp{get => isGrowUp; set => isGrowUp = value;}
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
