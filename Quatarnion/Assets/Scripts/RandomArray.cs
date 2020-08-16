using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArray : MonoBehaviour
{
    [SerializeField]
    string[] Name;
    [SerializeField]
    int[] Age;
    [SerializeField]
    string[] city;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int picker = Random.Range(0, 3);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log(Name[picker] + " Aged " + Age[picker] + " lives in " + city[picker]);
            foreach(var Name in Name)
            {
                Debug.Log(Name);
            }
        }

    }
}
