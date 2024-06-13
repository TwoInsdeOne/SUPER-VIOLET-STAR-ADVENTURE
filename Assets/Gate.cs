using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator ani;
    public bool enable;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Bullet" && enable) {
            ani.SetTrigger("open gate");
        }
    }
}
