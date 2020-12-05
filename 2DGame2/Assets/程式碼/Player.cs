using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Animator ani;
    public AudioSource aud;
    public AudioClip SoundFire;
    public Vector2 offset;
    public float radius = 0.3f;

    public void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }
    public void Start()
    {
        print("Hello World");
        Shoot(1, 500);
        Shoot(2, 600);
       
    }
    public void Update()
    {
        Move();
        Fire();
        Jump();
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
        //動畫的設定布林值(參數名稱，水平 不等於零時勾選)
        ani.SetBool("跑步開關", h != 0);
        //keycode 列單(下拉式選單) 所有輸入的選項:滑鼠、鍵盤、搖桿
        if(Input.GetKeyDown(KeyCode.D))
        {
            //此物件的變形元件
            //eulerAngles 歐拉角度
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            aud.PlayOneShot(SoundFire);
           GameObject temp = Instantiate(bullet, point.position,point.rotation);
            //讓子彈飛
            //上 綠 transform.up
            //右 紅 transform.right
            //左 藍 transform.forward
            temp.GetComponent<Rigidbody2D>().AddForce(transform.right* bulletspeed + transform.up*100);
        }
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        //如果角色在地板上面 並且按下空白鍵 才能跳躍
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(transform.up * jump);
        }
        //如果 物理 圖形 碰到圖層 8的地板物件
        else if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y) + offset, radius,1 << 8))
        {
            isGround = true;
        }
        //沒有碰到地板物件
        else
        {
            isGround = false;   //不再地面上了
        }
    }
    private void Dead(string obj)
    {
        if (obj == "死亡區域" || obj == "敵人子彈")
        {
            enabled = false;
            ani.SetBool("死亡觸發", true);
            //延遲呼叫("方法名稱",延遲時間)
            Invoke("Replay", 2.5f);
        }
    }
    private void Replay()
    {
        SceneManager.LoadScene("關卡1");
    }
    /// <summary>
    /// ODE碰撞時執行一次的事件
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision.gameObject.tag);
    }
    private void OnDrawGizmos()
    {
        //圖示 顏色
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        //圖示 繪製球體(中心點、半徑)
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y) + offset, radius);
    }
}
