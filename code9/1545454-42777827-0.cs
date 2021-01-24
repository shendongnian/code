	}
	
	// Update is called once per frame
	void Update (){
		if (toRight) {
			transform.Translate (Vector2.right*Time.deltaTime*speed, 0);
		}
		if (!toRight) {
			transform.Translate (Vector2.left*Time.deltaTime*speed, 0);
		}
			
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Crate" && kekanan) {
			toRight = false;
		} else {
			toRight = true;
		}
	}
}
