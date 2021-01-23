    void Update() {
        // Get the angle:
        float angle = GvrController.Orientation.eulerAngles.z;
        
        // The magic - clamp it:
        if(angle < -180f){
            angle = -180f;
        }else if(angle > 180f){
            angle = 180f;
        }
        
        // Apply it as a new rotation:
        transform.localRotation = Quaternion.AngleAxis(0f,0f,angle);
     }
