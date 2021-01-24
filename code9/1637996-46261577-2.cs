    public class CharacterController2D : MonoBehaviour {
    
    	// LayerMask to determine what is considered ground for the player
    	public LayerMask whatIsGround;
    
    	// Transform just below feet for checking if player is grounded
    	public Transform groundCheck;
    	
    	// store references to components on the gameObject
    	Transform transform;
    	Rigidbody2D rigidbody;
    	
    	bool isGrounded = false;
    	
    	float vy;
    	float vx;
    	
    	public float jumpForce = 600f;
    	
    	void Awake () {
    		transform = GetComponent<Transform> ();
    		rigidbody = GetComponent<Rigidbody2D> ();
    	}
    
        
        void Update()
    	{
    	
    	    // determine horizontal velocity change based on the horizontal input
    		vx = Input.GetAxisRaw ("Horizontal");
    		vy = rigidbody.velocity.y;
    	
    		// Check to see if character is grounded by raycasting from the middle of the player
    		// down to the groundCheck position and see if collected with gameobjects on the
    		// whatIsGround layer
    		isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, whatIsGround);
    		
    		if(isGrounded && Input.GetButtonDown("Jump")) // If grounded AND jump button pressed, then allow the player to jump
    		{
    			DoJump();
    		}
    		
    		// Change the actual velocity on the rigidbody
    		rigidbody.velocity = new Vector2(_vx * MoveSpeed, _vy);
    		
    	}
    	
    	//Make the player jump
    	void DoJump()
    	{
    		// reset current vertical motion to 0 prior to jump
    		vy = 0f;
    		// add a force in the up direction
    		rigidbody.AddForce (new Vector2 (0, jumpForce));
    
    	}
    }
