     simplecloudhander sch;
    
        void Start()
        {
         sch = GameObject.Find("nameOftheGameObject").GetComponent<simplecloudhander>();
        }
        void OnGUI() {
                GUI.Label (new Rect(100,300,300,50), "Metadata: " + sch .mTargetMetadata);
        
        }
