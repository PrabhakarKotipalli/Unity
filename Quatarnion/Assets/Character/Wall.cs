using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject BrokenWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {

            GameObject wallobj=Instantiate(BrokenWall, transform.position, Quaternion.Euler(0,90,0));
            Rigidbody[] walls = wallobj.GetComponentsInChildren<Rigidbody>();
            if(walls.Length > 0)
            {
                foreach(var body in walls)
                {
                    body.AddExplosionForce(500,transform.position,2);
                }
            }
            Destroy(this.gameObject);
        }
    }
}
