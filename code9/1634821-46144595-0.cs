    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class Player : MovingObjects {
    
    	protected override void AttemptMove<T> (int xDir, int yDir)
    	{
    		base.AttemptMove<T> (xDir, yDir);
    		RaycastHit2D hit;		
    	}
    	protected override void onCantMove<T>(T component)
    	{
    		Wall hitwall = component as Wall;
    		hitwall.DamageWall (wallDamage);		
    	}
    	
    	// Update is called once per frame
    	void Update () {
    			
    		int horizontal = 0;
    		int vertical = 0;
    		
    		horizontal = (int)Input.GetAxisRaw ("Horizontal");
    		vertical = (int)Input.GetAxisRaw ("Vertical");
    		
    		if (horizontal != 0)
    			vertical = 0;
    		
    		if (horizontal != 0 || vertical != 0)
    			AttemptMove<Wall> (horizontal, vertical);
    	}
    }
