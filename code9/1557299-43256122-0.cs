         if (Input.GetKey (KeyCode.W)) {
			sprint1 = true;
		} else {
			sprint1 = false;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			sprint2 = true;
		} else {
			sprint2 = false;
		}
		if (sprint2 == false && sprint1==false && !(Input.GetKey (KeyCode.A)) && !(Input.GetKey (KeyCode.S)) && !(Input.GetKey (KeyCode.D))){
			speed = 0;
		} if ((sprint1==true && sprint2==false) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)){
			
			speed = 4;
		}if (sprint1 == true && sprint2 == true && Scoped==true) {
			speed = 8;
		}
