using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletForce;
    private static Spawner _instance;
   
    public static Spawner Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Doesnt exist");
            return _instance;
        }
    }
    public void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BulletSpawner()
    {
        GameObject _bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        
        _bullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce,ForceMode.Force);
        Destroy(_bullet, 2f);
    }
}
