    private Collider collider ;
    
    void Start() {
        // Assuming this script goes on the head gameobject
        collider = this.GetComponent<Collider>();
    }
    void OnCollisionEnter(Collision col) {
        this.collider.isTrigger = true;
    }
    void OnTriggerExit(Collider other) {
        this.collider.isTrigger = false;
    }
