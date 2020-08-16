using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Shell : MonoBehaviour
{
    public GameObject Bulet_Shell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shell_Spawner()
    {
        
        GameObject _Shell = Instantiate(Bulet_Shell, transform.position, Quaternion.identity);
        _Shell.GetComponent<Rigidbody>().AddForce(transform.up * 2, ForceMode.Impulse);
        Destroy(_Shell, 2f);
    }
}
