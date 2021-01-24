    ThirdPersonCharacter tpsScript;
    
    void Start()
    {
        GameObject tpsObj = GameObject.Find("ThirdPersonController");
        tpsScript = tpsObj.GetComponent<ThirdPersonCharacter>();
    }
    
    void FixedUpdate()
    {
    
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
    
        Transform m_Cam = Camera.main.transform;
        Vector3 m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 m_Move = v * m_CamForward + h * m_Cam.right;
    
        tpsScript.Move(m_Move, false, false);
    }
