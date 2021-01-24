    using UnityEngine;
    
    public class PlayerMovement : MonoBehaviour
    {
    	public float speed = 6f;
    	Vector3 movement;
    	Rigidbody playerRigidbody;
    	int floorMask;
    	float camRaylength = 100f;
    	float JumpSpeed = 15f;
    
    	void Awake()
    	{
    		floorMask = LayerMask.GetMask("Floor");
    		playerRigidbody = GetComponent <Rigidbody> ();
    	}
    	void FixedUpdate()
    	{
    		float h = Input.GetAxisRaw ("Horizontal");
    		float v = Input.GetAxisRaw ("Vertical");
    
    		Move (h, v);
    		Turning ();
    		if(Input.GetKeyDown(KeyCode.Space))
    			Jump();
    
    	}
    
    	void Jump()
    	{
    		playerRigidbody.isKinematic=false;
    		playerRigidbody.AddForce(Vector3.up *JumpSpeed);
    
    	}
    
    	void Move(float h, float v)
    	{
    		movement.Set(h, 0f, v);
    
    		movement = movement.normalized * speed * Time.deltaTime;
    
    		playerRigidbody.MovePosition (transform.position + movement);
    	}
    
    	void Turning()
    	{
    		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
    
    		RaycastHit floorHit;
    
    		if (Physics.Raycast (camRay, out floorHit, camRaylength, floorMask)) {
    
    			Vector3 playerToMouse = floorHit.point - transform.position;
    			playerToMouse.y = 0f;
    
    			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
    			playerRigidbody.MoveRotation (newRotation);
    
    		}
    	}
    
    	void Animating(float h, float v)
    	{
    		bool walking = h != 0f || v != 0f;
    
    	}
        
    }
