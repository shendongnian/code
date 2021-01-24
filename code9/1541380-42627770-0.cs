    void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Player") )
        {
            m_IsPlayerOnTheMap = true;
        } 
    }
    void OnTriggerExit(Collider other)
    {
        if( other.gameObject.CompareTag("Player") )
        {
            m_IsPlayerOnTheMap = false;
        }
    }
    void Update()
    {
    #if DEBUG
        if ( m_IsPlayerOnTheMap )
        {
            Debug.Log("Map ON");
        }
        else
        {
            Debug.Log("Map OFF");
        }
    #endif
    }
    private bool m_IsPlayerOnTheMap = false;
