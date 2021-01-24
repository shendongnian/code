    public int offstX= 937;
    public int offstY= 520;
   
    bool isInited=false;
    void Update() {
        uint playerID;
        if(manager != null){
            playerID = manager.GetPlayer1ID();
        }else{ playerID = 0; }
        if(playerID <= 0) {
            //reset all the position to the initial values 
            if (transform.position != initialPosition) {
                transform.position = initialPosition;
            }
            //reset all the rotation to the initial values 
            if (transform.rotation != initialRotation)
            {
                transform.rotation = initialRotation;
            }
            for (int i = 0; i < bones.Length; i++)
            {
                bones[i].gameObject.SetActive(true);
                bones[i].transform.localPosition = Vector3.zero;
                bones[i].transform.localRotation = Quaternion.identity;
                if (SkeletonLine)
                {
                    lines[i].gameObject.SetActive(false);
                }
            }
            return;
        }
        //set the user position in space 
        Vector3 positionPointMan = manager.GetUserPosition(playerID);
        */
        float initialXposition = transform.localPosition.x;
        float initialYposition = transform.localPosition.y;
        float nextXposition=0;
        float nextYposition=0;
        KinectManager manager = KinectManager.Instance; // call the Kinect instance
        if (DepthImageViewer.Instance.jointColliders != null)
        {
            if (manager.Player1Calibrated && isInited == false)
            {
                isInited = true;
                Debug.Log("Kinect See Your hand");
                transform.localPosition = new Vector2(0, 0);
                nextXposition = transform.localPosition.x;
                nextYposition = transform.localPosition.y;
                if (initialXposition != nextXposition && initialYposition != nextYposition)
                {
                    Debug.Log("I moved the cursor the the initial pisition");
                }
                else
                    Debug.Log("Sorry I didn't translate the cursor");
            } else if (manager.Player1Calibrated && isInited == true)
            {
                float XvalueAre = DepthImageViewer.Instance.jointColliders[11].transform.localPosition.x * 192.0f + 184430.4f;
                float YvalueAre = DepthImageViewer.Instance.jointColliders[11].transform.localPosition.y *108.0f + 58832.1f;
             
                  
            Vector2 newPos = new Vector2(XvalueAre - offstX, YvalueAre - offstY);// - initialPosition ,DepthImageViewer.Instance.jointColliders[11].transform.position.z) - initialPosition;
                Debug.Log("Your Hand X position => " + DepthImageViewer.Instance.jointColliders[11].transform.localPosition.x);
                Debug.Log("Your Hand Y position => " + DepthImageViewer.Instance.jointColliders[11].transform.localPosition.y);
                Debug.Log("Your Converted Hand X position => " + XvalueAre);
                Debug.Log("Your Converted Hand Y position => " + YvalueAre);
                transform.position = newPos;
            }
      
      
         }
        else
            Debug.Log("Erreur remplir joints colliders ");
    }
