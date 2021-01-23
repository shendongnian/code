    void Start ()
    {
        StartCoroutine("RotatePlayerDelay");        
    }
    
    IEnumerator RotatePlayerDelay()
    {
        while(true)
        {
            Debug.Log("1");
            firstPersonController.m_MouseLook.myAngle += 10; // here I have +20, not +10
            yield return new WaitForSeconds(0.005f);
            firstPersonController.m_MouseLook.myAngle = 0;
            Debug.Log("2");
            yield return new WaitForSeconds(0.005f);
        }
    }
