using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growCapsule : Collectable
{
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("derived class");
    }

    // Update is called once per frame
    void Update()
    {
        moveRotate();
    }

    public override void moveRotate()
    {
        transform.Rotate(new Vector3(60, 60, 60) * Time.deltaTime);

    }
}
