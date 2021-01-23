    public GvrViewer MonoOrStereo = new GvrViewer(); 
    public bool stereo;
    
    void Awake() { 
        stereo = MonoOrStereo.VRModeEnabled; 
    } 
    
    public void LoadStereo(bool stereo) { 
        Debug.Log (stereo); 
    }
