using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("這角色速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("這角色跳躍"), Range(0, 3000)]
    public int jump = 100;
    public bool isGround = false;
    private int score = 0 ;
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
}
