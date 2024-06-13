using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int hpMax;
    public int hp;
    public int damage;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if(hp > 0)
        {
            hp -= damage;
            if(hp <= 0)
            {
                hp = 0;
                Death();
            }
        }
    }
    public void Death()
    {
        ani.SetTrigger("Death");
        Destroy(gameObject.GetComponent<AIDestinationSetter>());
        Destroy(gameObject.GetComponent<Patrol>());
        Destroy(gameObject.GetComponent<AIPath>());
        Destroy(gameObject.GetComponent<Seeker>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
        }
    }
}
