using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody[] rigids = GetComponentsInChildren<Rigidbody>();
            if(rigids.Length > 0)
            {
                foreach(var obj in rigids)
                {
                    obj.AddExplosionForce(500, transform.position, 5);

                }
            }
            
        }
    }
}
