using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControl playerControl;
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    public SpriteRenderer sr2;
    private CircleCollider2D cc;
    private Vector2 direction;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        playerControl = new PlayerControl();
        playerControl.Movement.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = playerControl.Movement.Move.ReadValue<Vector2>().normalized;
        if(Mathf.Abs(direction.x) + Mathf.Abs(direction.y) > 0) {
            rb.AddForce(new Vector2(direction.x * speed, direction.y * speed));
        }
        if(direction.x < 0) {
            sr.flipX = true;
            cc.offset = new Vector2(-0.125f, 0.005f);
            sr2.transform.localPosition = new Vector3(-0.125f, 0.005f, 0f);
        }
        if(direction.x > 0) {
            sr.flipX = false;
            cc.offset = new Vector2(0.125f, 0.005f);
            sr2.transform.localPosition = new Vector3(0.125f, 0.005f, 0f);
        }
    }
}
