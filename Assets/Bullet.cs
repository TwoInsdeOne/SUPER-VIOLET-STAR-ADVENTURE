using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 direction;
    public float speed;
    public GameObject bulletExitFX;
    public GameObject bulletdeathFX;
    private float timealive;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(direction.x * speed, direction.y * speed), ForceMode2D.Impulse);
        GameObject bef = Instantiate(bulletExitFX);
        bef.transform.position = transform.position;
    }
    private void Update() {
        timealive += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(timealive > 0.03f) {
            GameObject bdf = Instantiate(bulletdeathFX);
            bdf.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
