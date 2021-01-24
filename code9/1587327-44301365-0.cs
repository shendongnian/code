    // Assuming target1 is player 1 and target2 is player 2
    private float snapThreshold = 0.1f;
    
    private Vector3 movingCameraDestination = Vector3.zero; 
    
    void FixedUpdate()
    {
        if(Input.GetButtonDown("Control"))
        {
            if(isCurrentPlayer)
            {
                //Set position of transition camera to player 1 and set it's destination to player's 2 position
                movingCamera.transform.position = player1.position;
                movingCameraDestination = player2.position;
                
                //Disable player 1 camera and enable transition camera
                cam1.enabled = false;
                movingCamera.enabled = true;
            }
            else
            {
                //Set position of transition camera to player 21 and set it's destination to player's 1 position
                movingCamera.transform.position = player2.position;
                movingCameraDestination = player1.position;
                
                //Disable player 1 camera and enable transition camera
                cam2.enabled = false;
                    movingCamera.enabled = true;
            }
        }
        
        //If transition camera is enabled and its destination is not Vector3.zero - move it
        if(movingCameraDestination != Vector3.zero && movingCamera.enabled)
        {
            movingCamera.transform.position = Vector3.Lerp(movingCamera.transform.position, movingCameraDestination, speed * Time.deltaTime);
            
            //If the distance between transition camera and it's destination is smaller or equal to threshold - snap it to destination position
            if(Vector3.Distance(movingCamera.transform.position, movingCameraDestination) <= snapThreshold)
            {
                movingCamera.transform.position = movingCameraDestination;
            }
            
            //If transition camera reached it's destination set it's destination to Vector3.zero and disable it
            if(movingCamera.transform.position == movingCameraDestination)
            {
                movingCameraDestination = Vector3.zero;
                movingCamera.enabled = false;
            }
        }
    }
