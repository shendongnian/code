    public class RobotController: MonoBehaviour
    {
        public float maxSpeed = 2f;
        //a boolean value to represent whether we are facing left or not
        bool facingLeft = true;
        //a value to represent our Animator
        Animator anim;
    
        //Declare rigid2D
        Rigidbody rigid2D;
        // Use this for initialization
        void Start()
        {
            //set anim to our animator
            anim = GetComponent<Animator>();
            //Initialize rigid2D
            rigid2D = GetComponent<Rigidbody>();
        }
    
        // Update is called once per frame
        void FixedUpdate()
        {
    
            float move = Input.GetAxis("Horizontal");//Gives us of one if we are moving via the arrow keys
                                                     //move our Players rigidbody
            rigid2D.velocity = new Vector3(move * maxSpeed, rigid2D.velocity.y);
            //set our speed
            anim.SetFloat("Speed", Mathf.Abs(move));
            //if we are moving left but not facing left flip, and vice versa
            if (move < 0 && !facingLeft)
            {
    
                Flip();
            }
            else if (move > 0 && facingLeft)
            {
                Flip();
            }
        }
    
        //flip if needed
        void Flip()
        {
            facingLeft = !facingLeft;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
