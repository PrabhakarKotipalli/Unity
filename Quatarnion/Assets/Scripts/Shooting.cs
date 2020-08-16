using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera fpscam;
    public float Damage = 10f;
    public float Range = 100f;
    public ParticleSystem MuzzleFlash;
    public Bullet_Shell Shell;
    public AudioSource Fire;
    public Animator _Animator;
    public GameObject effect;
    private Vector3 Original_Recoil;
    public Vector3 upRecoil;
    // Start is called before the first frame update
    void Start()
    {
        Fire = GetComponent<AudioSource>();
        _Animator = GetComponent<Animator>();
        Original_Recoil = transform.localEulerAngles;
        //Debug.Log(Original_Recoil);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            AddRecoil();
           // _Animator.SetTrigger("Gun");
            Fire.Play();
            Shoot();
            Shell.Shell_Spawner();
            MuzzleFlash.Play();
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopRecoil();
        }
    }
    public void Shoot()
    {
        RaycastHit Hit;
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out Hit, Range))
        {
            Debug.Log(Hit.transform.position);
            // Vector3 item = Hit.transform.position;
            //GameObject bullet_effect = Instantiate(effect, item, Quaternion.identity);
            //Destroy(bullet_effect, 2f);
            Rigidbody _r = Hit.transform.GetComponent<Rigidbody>();
            if(_r!= null)
            {
                _r.AddForce(transform.forward*10, ForceMode.Force);
            }
            
            Look Enemy_Boss = Hit.transform.GetComponent<Look>();
            if(Enemy_Boss != null)
            {
                Enemy_Boss.TakeDamage(10f);
            }
        }
    }
    public void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }
    public void StopRecoil()
    {
        transform.localEulerAngles = Original_Recoil;
    }
   
}
