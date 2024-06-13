using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration;
    public float currentTimer;
    public float frequency;
    public float radius;
    private float startShake;
    private float waveClock;
    // Start is called before the first frame update
    void Start()
    {
        waveClock = 0;
        currentTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimer > 0) {
            transform.localPosition = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), 0);
            currentTimer -= Time.deltaTime;
        } else {
            transform.localPosition = Vector3.zero;
        }
    }
    public void StartShake() {
        currentTimer = duration;
    }
    public void StartShakeFor(float time)
    {
        currentTimer = time;
    }
}
