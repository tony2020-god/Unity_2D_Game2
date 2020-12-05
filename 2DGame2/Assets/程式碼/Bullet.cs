using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameObject temp = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(temp, 1);
    }
}
