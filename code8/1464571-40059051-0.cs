    private Renderer[] sueloRenderers;
    
    void Start()
    {
        GameObject[] suelo = GameObject.FindGameObjectsWithTag("SueloWireframe");
        sueloRenderers = new Renderer[suelo.Length];
        for (int i = 0; i < sueloRenderers.Length; i++)
        {
            sueloRenderers[i] = suelo[i].GetComponent<Renderer>();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "Player")
        {
            EnableRenderer(sueloRenderers, false);
            Debug.Log("Oculta suelo");
    
        }
    }
    
    void OnTriggerExit(Collider other)
    {
    
        if (other.gameObject.tag == "Player")
        {
            EnableRenderer(sueloRenderers, true);
            Debug.Log("Aparece suelo");
    
        }
    }
    
    void EnableRenderer(Renderer[] rd, bool enable)
    {
        for (int i = 0; i < rd.Length; i++)
        {
            rd[i].enabled = enable;
        }
    }
