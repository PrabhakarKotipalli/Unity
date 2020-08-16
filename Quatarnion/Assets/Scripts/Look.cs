using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public Transform AttackRangeSpot;
    public float AttackRange;
    public LayerMask PlayerLayer;
    public Transform Player;
    Collider[] Obj;
    public float Speed;
    public float MaxHealth = 100f;
    public float Current_health;
    // Start is called before the first frame update
    void Start()
    {
       Current_health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Obj = Physics.OverlapSphere(AttackRangeSpot.position, AttackRange, PlayerLayer);
        foreach(Collider i in Obj)
        {
            Player.position = i.GetComponent<Transform>().position;
            Vector3 dir = Player.position - transform.position;
            Quaternion desired_rotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, desired_rotation, Speed);
            RaycastHit Hit;
            if (Physics.Raycast(transform.position, transform.forward, out Hit))
            {

                if(Hit.transform.name == "Player")
                {
                    Spawner.Instance.BulletSpawner();
                }
            }
            Debug.DrawRay(transform.position, dir);
            
            //Spawner.Instance.BulletSpawner();
        }
        
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackRangeSpot.position, AttackRange);
    }
    public void TakeDamage(float Damage)
    {
        Current_health -= Damage;
        if(Current_health<0)
        {
            Destroy(this.gameObject);
        }
    }

}
