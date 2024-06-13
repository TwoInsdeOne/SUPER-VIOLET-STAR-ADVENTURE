using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballFloaer : MonoBehaviour
{
    public Vector2 anchorPoint;
    // Start is called before the first frame update
    void Start()
    {
        anchorPoint = transform.GetChild(0).gameObject.GetComponent<SpringJoint2D>().connectedAnchor;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bPos = transform.GetChild(0).position;
        transform.GetChild(1).position = new Vector2((bPos.x + anchorPoint.x)/2f, (bPos.y + anchorPoint.y)/2);
        float angle = Mathf.Atan2(bPos.y - anchorPoint.y, bPos.x - anchorPoint.x) + Mathf.PI/2f;
        transform.GetChild(1).eulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg);
        transform.GetChild(1).localScale = new Vector3(0.1f,(bPos - anchorPoint).magnitude, 0.1f);
    }
}
