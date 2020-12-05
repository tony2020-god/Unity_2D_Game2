using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] lives;

    public Text textScore;
    private int live = 3;
    private void Awake()
    {
        SetCollision();
        SetLive();
    }
    private void SetLive()
    {
        for (int i=0;i<lives.Length;i++)
        {
            //判斷式 只有一行敘述時 可以省略 大括號
            if (i >= live) lives[i].SetActive(false);
        }
    }
    private void SetCollision()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("玩家"), LayerMask.NameToLayer("玩家子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人"), LayerMask.NameToLayer("敵人子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("玩家子彈"), LayerMask.NameToLayer("敵人子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人子彈"), LayerMask.NameToLayer("敵人子彈"));
    }
     
}
