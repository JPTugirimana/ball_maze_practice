using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    //private Vector3 normalizeDirection;

    public Transform target;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        name = "bye";

        Debug.Log(name);

        //normalizeDirection = (target.position - transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {


        //transform.position += normalizeDirection * speed * Time.deltaTime;
        transform.LookAt(target.position);

        if ((transform.position - target.position).magnitude > 0.1f)
            transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);

    }
}
