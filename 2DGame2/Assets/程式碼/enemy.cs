using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("子彈"), Tooltip("用來儲存子彈的預置物")]
    public GameObject bullet;
    public Transform point;
    [Header("子彈速度"), Range(0, 5000)]
    public int bulletspeed = 800;
    public AudioClip SoundFire;
    [Header("追蹤系統"),Range(0,1000)]
    public float rangeTrack = 10.5f;
    [Header("攻擊範圍"), Range(0, 1000)]
    public float rangeAttack = 8.5f;
    private Transform player;
    private Rigidbody2D rig;
    [Header("攻擊間隔"),Range(0,5)]
    public float intervalAttack = 2.5f;
    private AudioSource aud;
    private float timer;
    private Animator ani;
    private GameManager gm;
    public int score = 50;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        //玩家變形 = 遊戲物件.尋找("玩家物件名稱").變形
        player = GameObject.Find("玩家").transform;
        aud = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();

        gm = FindObjectOfType<GameManager>();
    }

    private void Move()
    {
       if (player.position.x > transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
       else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        float dis = Vector3.Distance(player.position, transform.position);
        if (dis < rangeAttack)
        {
            Fire();
        }
        else if(dis < rangeTrack)
        {
            rig.velocity = transform.right * speed;
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y);
        }
    }

    private void Fire()
    {

        rig.velocity =new Vector2(0,rig.velocity.y); //加速度 = x0,y，原本的Y
        //如果 計時器 大於等於 間隔 就攻擊
        if (timer >= intervalAttack)
        {
            timer = 0;
            aud.PlayOneShot(SoundFire, Random.Range(0.3f, 0.5f));  //播放音效
            GameObject temp = Instantiate(bullet, point.position, point.rotation); //生成子彈
            temp.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletspeed + transform.up * 100); //子彈賦予推力
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void Dead()
    {
       
        enabled = false;
        ani.SetBool("死亡觸發", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        rig.Sleep();
        //Destroy(gameObject, 2.5f);
        gm.AddScore(score);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeTrack);

        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "子彈")
        {
            Dead();
        }
    }

}
