using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShot : MonoBehaviour
{
    private PlayerControl playerControl;
    private Rigidbody2D rb;
    public Transform aim;
    private Vector2 aimDirection;
    public Camera mainCamera;
    public Transform bulletExitPosition;
    public GameObject bullet;
    public Shake shake;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControl = new PlayerControl();
        playerControl.Action.Enable();
        playerControl.Action.Shot.Disable();
        playerControl.Action.Shot.started += Shot;
        aim.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() { 

        Vector2 actionMousePosition1 = playerControl.Action.MousePosition.ReadValue<Vector2>();
        Vector3 actionMousePosition2 = new Vector3(actionMousePosition1.x, actionMousePosition1.y, 10);
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(actionMousePosition2);
        aimDirection = (new Vector2(transform.position.x, transform.position.y) - mousePosition) * (-1);

        aim.eulerAngles = new Vector3(0, 0, Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg);
    }
    public void Shot(InputAction.CallbackContext context) {
        shake.StartShakeFor(0.15f);
        GameObject b = Instantiate(bullet);
        b.transform.position = bulletExitPosition.position;
        b.GetComponent<Bullet>().direction = aimDirection.normalized;
        rb.AddForce(aimDirection.normalized*(-1), ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Canon Item")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Absorb");
            Destroy(collision.gameObject, 2f);
            playerControl.Action.Shot.Enable();
            aim.gameObject.SetActive(true);
        }
    }
}
