using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] GameObject resetTimeHolder;
    
    //config
    [SerializeField] float runSpeed = 6f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(20f, 20f);
    //state
    bool isAlive = true;

    //new code
    public bool grounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    int extraJump;
    public int extraJumpValue;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip rewindSound;

    //cache references
    Rigidbody2D myBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        extraJump = extraJumpValue;
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {   
        if(!isAlive) { return; }

        if(grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround))
        {
            grounded = true;
        }
        

        Run();
        Jump();
        ClimbLadder();
        FlipSprite();
        Die();
    }
    private void Run()
    {

        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed,myBody.velocity.y);
        myBody.velocity = playerVelocity;

        bool PlayerHasHorizontalSpeed = Mathf.Abs(myBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running",PlayerHasHorizontalSpeed);
        
    }

    private void Jump()
    {   
     
        if(CrossPlatformInputManager.GetButtonDown("Jump") && grounded == true)
        {
            float jumpvelocity = 24f;
            myBody.velocity = Vector2.up * jumpvelocity;
            AudioSource.PlayClipAtPoint(jumpSound, transform.position, 20f);
            ViewTimer();
            grounded = false;
        }
    }
   
    public void ViewTimer()
    {
        //ResetTimerController.instance.StartResetTime();        
    }
    private void ClimbLadder()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"))) 
        {
            myAnimator.SetBool("Climbing", false);
            myBody.gravityScale = gravityScaleAtStart;
            return; 
        }
                   
            float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(myBody.velocity.x, controlThrow * climbSpeed);
            myBody.velocity = climbVelocity;
            myBody.gravityScale = 0;

            bool PlayerHasVerticalSpeed = Mathf.Abs(myBody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("Climbing", PlayerHasVerticalSpeed);
        
    }
    private void Die()
    {
        if(myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Die");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();

        }
    }

    
    private void FlipSprite()
    {
        bool PlayerHasHorizontalSpeed = Mathf.Abs(myBody.velocity.x) > Mathf.Epsilon;
        if(PlayerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myBody.velocity.x),1f);
        }

    }
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            RestTimer.instance.AddTime();
            
        }
    }
    public void RewindSound()
    {
        AudioSource.PlayClipAtPoint(rewindSound, transform.position, 20f);
    }
}
