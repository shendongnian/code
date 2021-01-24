    if(Input.GetKey(KeyCode.RightArrow)){
	   physicsPlayer.velocity = new Vector2(1,1) * moveSpeed;
    }
    if(Input.GetKey(KeyCode.UpArrow)){
	    physicsPlayer.velocity = new Vector2(-1,1) * moveSpeed;
    }
