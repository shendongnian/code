    void CallStun(Collider2D coll){
		if (coll.gameObject.tag == "Enemy") {
			coll.GetComponent<EnemyHealth> ().TakeDamage (damage);
			coll.GetComponent<EnemyMovement> ().Slow (3, 0f);
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (stun == false) {
			return;
		}
		if (!collList.Contains (other)) {    //if the object is not already in the list
			collList.Add (other);    //add the object to the list
			CallStun (other);    //call the functions on the specific object
		} else {
			Destroy (gameObject);    //if no(more) collisions occur -> destroy the circle object
		}
	}
