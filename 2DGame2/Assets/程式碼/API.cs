using UnityEngine;

public class API : MonoBehaviour
{
    private void Start()
    {
        print(Mathf.PI);
        print("隨機亂數" + Random.value);
        Time.timeScale = 0.5f;
        int a = Mathf.Abs(-999);
        print("取絕對值後的值為" + a);
        float atk = Random.Range(0.5f, 1f);
        print("隨機攻擊力" + atk);
        print("攝影機總數:" + Camera.allCamerasCount);
        Cursor.visible = false;
    }
    private void Update()
    {
        print("是否按任意鍵:" + Input.anyKey);
        print("遊戲時間 : " + Time.time);
    }
}
