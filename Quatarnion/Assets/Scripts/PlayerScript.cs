using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody _rigid;
    public float Speed = 10f;
    private float MaxHealth = 300f;
    public float currentHealth;
    public CharacterController _charactercontroller;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float groundRadius = 0.4f;
    public Transform groundCheckPoint;
    public LayerMask groundLayer;
    [SerializeField]
    bool isgrounded;
    public float JumpForce = 3f;
    public Animator _animator;
    public Bullet_Shell Shell;
    public Vector3 Initial_Position;
    // Start is called before the first frame update
    void Start()
    {
        isgrounded=Physics.CheckSphere(groundCheckPoint.position, groundRadius, groundLayer);
        _rigid = GetComponent<Rigidbody>();
        currentHealth = MaxHealth;
        _animator = GetComponent<Animator>();
        Initial_Position = transform.position;
        //_charactercontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheckPoint.position, groundRadius, groundLayer);
        if (isgrounded && velocity.y<0)
        {
            velocity.y = -2;
        }
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 Movement = transform.right * horizontal + transform.forward * vertical;
        //transform.Translate(new Vector3(-vertical, 0, horizontal));
        _charactercontroller.Move(Movement * Speed * Time.deltaTime);
        // _rigid.velocity += new Vector3(-vertical,0,horizontal);

        //_animator.SetFloat("v", vertical);
        //_animator.SetFloat("h", horizontal);
        
        if(Input.GetButtonDown("Jump")&&isgrounded)
        {
            velocity.y = Mathf.Sqrt(JumpForce * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        _charactercontroller.Move(velocity * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(Time.time);
        }

    }
    
    public void TakeDamage(float Damage)
    {
        currentHealth -= Damage;
        if(currentHealth <= 0)
        {
            transform.position = Initial_Position;
            //Destroy(this.gameObject);
        }
    }
    /*public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            TakeDamage(2f);
        }
    }
    */
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Bullet")
        {

            TakeDamage(2f);
        }
    }


}
