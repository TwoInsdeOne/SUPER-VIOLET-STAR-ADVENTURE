using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShrinkPower : MonoBehaviour
{
    private PlayerControl playerControl;
    public GameObject GFX;
    public GameObject ShrinkVFX;
    public bool isShrunk;
    public CircleCollider2D circleCollider;
    private float radius;
    // Start is called before the first frame update
    void Start()
    {

        playerControl = new PlayerControl();
        playerControl.Action.Shrink.Disable();
        playerControl.Action.Shrink.started += Shrink;
        radius = circleCollider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shrink(InputAction.CallbackContext context)
    {
        if (!isShrunk)
        {
            isShrunk = true;
            GFX.SetActive(false);
            ShrinkVFX.SetActive(true);
            circleCollider.radius = radius / 2f;
        } else
        {
            isShrunk = false;
            GFX.SetActive(true);
            ShrinkVFX.SetActive(false);
            circleCollider.radius = radius;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Shrink Star")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Absorb");
            Destroy(collision.gameObject, 2f);
            playerControl.Action.Shrink.Enable();
        }
    }
}
