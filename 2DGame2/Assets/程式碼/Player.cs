using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int jump = 100;
    [Header("是否在地板上"), Tooltip("用來儲存玩家是否在地板上")]
    public bool isGround = false;
    private int score = 0 ;
    [Header("子彈"), Tooltip("用來儲存子彈的預置物")]
    public GameObject bullet;
    public Transform point;
    [Header("子彈速度"), Range(0, 5000)]
    public int bulletspeed = 800;
    public AudioClip music;
    [Header("角色生命"), Range(0, 10)]
    public int life = 3;
    public Rigidbody2D rig;
    public Animation ani;

    public void Start()
    {
        print("Hello World");
        Shoot(1, 500);
        Shoot(2, 600);
    }
    public void Update()
    {
        Move();
    }
    private void Drive(float speed)
    {
        print("開車中");
        transform.Translate(speed,0, 0);
    }
    /// <summary>
    /// 發射弓箭的功能
    /// </summary>
    /// <param name="count">弓箭數量</param>
    /// <param name="speed">弓箭發射速度，預設值為300</param>
    private void Shoot(int count ,int speed=300)
    {
        print("發射弓箭" + count);
        print("弓箭速度" + speed);
    }
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //水平浮點數 = 輸入 的 取得軸向("水平")-左右AD
        float h = Input.GetAxis("Horizontal");
        //剛體 的 加速度 = 新 二維向量(水平浮點數 * 速度, 剛體的加速度Y)
        rig.velocity = new Vector2(h * speed, rig.velocity.y);
        print("水平數值" + h);
    }
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Fire()
    {

    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {

    }

}
