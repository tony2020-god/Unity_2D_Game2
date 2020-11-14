using UnityEngine;

public class car : MonoBehaviour
{
    [Header("這是汽車的cc數")]
    public int cc = 200;
    [Header("這是汽車的重量"), Range (500, 1000)]
    public float weight = 1500.5f;
    public string brand = "BNW";
    [Header("是否有天窗")]
    [Tooltip("勾選代表有天窗")]
    public  bool window = true;


    public Color red = Color.red;
    public Color yellow = Color.yellow;
    public Color mycolor = new Color(0.3f, 0, 0.9f);

    public Vector2 pos0 = Vector2.zero;
    public Vector2 pos1 = Vector2.one;
    public Vector2 pos2 = new Vector2(7, 9);

    public Vector3 posv3 = Vector3.one;
    public Vector4 posv4 = Vector4.one;

    public GameObject obj;
    public Transform tra;
    public SpriteRenderer spr;

}
