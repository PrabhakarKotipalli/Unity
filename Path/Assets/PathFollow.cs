using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.IO;

public class PathFollow : MonoBehaviour
{
    public PathCreator pathcreator;
    public float Speed;
    float distanceTravelled;
    public Rigidbody _rigid;
    public float JumpForce;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += Speed * Time.deltaTime;
        transform.position = pathcreator.path.GetPointAtDistance(distanceTravelled) + new Vector3(0, 0.2f, 0);
        transform.rotation = pathcreator.path.GetRotationAtDistance(distanceTravelled);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressed");
            _rigid.AddForce(new Vector3(-1,0,0)*JumpForce*Time.deltaTime,ForceMode.Impulse);
        }
        
    }
}
