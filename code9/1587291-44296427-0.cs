    void OnTriggerStay(Collider other){
        isGrounded = true;
    }
    void OnTriggerExit(Collider other){
        isGrounded = false;
    }
