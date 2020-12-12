using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] lives;

    public Text textScore;
    public static int live = 3;
    public static int score = 0;
    [Header("結束畫面")]
    public GameObject final;
    private void Awake()
    {
        SetCollision();
        SetLive();
        AddScore(0);
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
     public void AddScore(int add)
    {
        score += add; //累加分數
        textScore.text = "分數" + score; //更新文字介面
    }
    /// <summary>
    /// 玩家死亡
    /// </summary>
    public void PlayerDead()
    {
        live--;

        SetLive();

        if (live == 0) final.SetActive(true);
    }
    private void Update()
    {
        BakeToMenu();
        QuitGame();
    }
    private void BakeToMenu()
    {
        if (live == 0 && Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene("選單");
    }
    private void QuitGame()
    {
        if (live == 0 && Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
