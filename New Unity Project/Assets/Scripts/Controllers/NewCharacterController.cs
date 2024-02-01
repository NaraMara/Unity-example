
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewCharacterController : MonoBehaviour
{

    [SerializeField] public float JumpVelocity;
    [SerializeField] public float moveSpeed;
    public Animator animator;
    public Transform RespawnPoint;
   


    [SerializeField] private LayerMask groundlayerMask;
    [SerializeField] private Transform m_GroundCheck;


    const float k_GroundedRadius = .2f;
    private bool m_FacingRight;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private CircleCollider2D circleCollider2d;
    private bool scndJump;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void  Update()
    {
        if (isGrounded()) scndJump = true;
        
        if ( Input.GetKeyDown(KeyCode.Space))
            if (isGrounded())
            {
                animator.SetBool("isJumping", true);
                animator.SetTrigger("Jumped");
                rigidbody2d.velocity = Vector2.up * JumpVelocity;
            }
            else if(scndJump) {
            scndJump = false;
            rigidbody2d.velocity = Vector2.up * JumpVelocity;
                animator.SetTrigger("DoubleJumped");
                
            }

        Movement();

        

    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRunning", true);
            if (!m_FacingRight)
            {
                Flip();
            }
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);

        }else{
           if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isRunning", true);

                if (m_FacingRight) Flip();

                rigidbody2d.velocity = new Vector2(moveSpeed, rigidbody2d.velocity.y);

            }else
            {
                // no input 
                animator.SetBool("isRunning", false);

                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }

        }

    }
    private bool isGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, groundlayerMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                animator.SetBool("isJumping", false);
                 
                return true;
            }


        }
        return false;
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            moveSpeed /= 2;
        }

        if (collision.gameObject.CompareTag("End of Realm"))
        {
            
                BackToHub();
            
        }
        if (collision.gameObject.CompareTag("DeathZone"))
        {

            Respawn();

        }
        if (collision.gameObject.CompareTag("Green Portal"))
        {

            SceneManager.LoadScene(3);
        }
        if (collision.gameObject.CompareTag("Purple Portal"))
        {

            SceneManager.LoadScene(4);
        }
        if (collision.gameObject.CompareTag("The END"))
        {

            SceneManager.LoadScene(5);
        }
        if (collision.gameObject.CompareTag("coin"))
        {

          
        }

    }

    public void BackToHub()
    {
        SceneManager.LoadScene(2);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            moveSpeed *= 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slime") )
        {
            if (isGrounded())
            {

                Respawn();
                
            }
            else
            {
                GameObject go = collision.gameObject;
                go.GetComponentInChildren<Animator>().SetTrigger("Dead");
                go.GetComponent<SlimeController>().death();
                rigidbody2d.velocity = Vector2.up * JumpVelocity;

            }
        }
    }
    public void Respawn()
    {
        gameObject.transform.position = RespawnPoint.position;

    }


}
