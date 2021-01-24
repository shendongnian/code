    void Update () {
    
    	clickTimer -= Time.deltaTime;
    	
    	if(clickTimer <= 0){
    	
    		if(Input.GetMouseButtonDown(0)) {
    		
    			//What point was pressed
    			Vector3 worldPoint = Camera.main.ScreenToWorldPoint( Input.mousePosition );
    			worldPoint.z = Camera.main.transform.position.z;
    			//Generate a Ray from the position you clicked in the screen
    			Ray ray = new Ray( worldPoint, new Vector3( 0, 0, 1 ) );
    			//Cast the ray to hit elements in your scene
    			RaycastHit2D hit = Physics2D.GetRayIntersection( ray );
    
    			if(hit.collider != null) {
    				 Debug.Log("I hit: "+hit.gameObject.tag);
    				//And here you can check what GameObject was hit
    
    				if(hit.gameObject.tag == "AnyTag"){
    					 //Here you can do whatever you need for AnyTag objects
    				}
    			}
    		}	
    		
    		clickTimer = 2f;
    	}
    }
