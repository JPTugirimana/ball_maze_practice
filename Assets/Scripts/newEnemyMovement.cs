using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newEnemyMovement : MonoBehaviour
{

    public Transform target;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position);

        if ((transform.position - target.position).magnitude > 0.1f)
            transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            this.transform.localPosition = new Vector3(0, 0, 0);
        }

    }

}
