    Quaternion startRotation;
    Quaternion endRotation;
    float rotationProgress = -1;
   
    // Call this to start the rotation
    void StartRotating(float zPosition){
        // Here we cache the starting and target rotations
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zPosition);
        // This starts the rotation, but you can use a boolean flag if it's clearer for you
        rotationProgress = 0;
    }
    
    void Update() {
        if (rotationProgress < 1 && rotationProgress >= 0){
            rotationProgress += Time.deltaTime * 5;
            // Here we assign the interpolated rotation to transform.rotation
            // It will range from startRotation (rotationProgress == 0) to endRotation (rotationProgress >= 1)
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
        }
    }
