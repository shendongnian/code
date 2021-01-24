    // If you are sprinting, set the speed to 8
    if (sprint1 == true && sprint2 == true && Scoped==true) {
        speed = 8;
    }
    // Else if one of those keys have been touched during this frame, set the speed to 4
    else if (sprint2==false && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))){
        speed = 4;
    }
    // Else, just set the speed to 0
    else
        speed = 0;
