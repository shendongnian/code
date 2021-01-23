    GameObject leafObject;
    
    void OnTriggerEnter ( Collider other) {
        if (other.gameObject.tag == "leaf1"){
            leafObject = other.gameObject;
            StartCoroutine (LeafDestruction ());
        }
    }
    
    IEnumerator LeafDestruction(){
        yield return new WaitForSeconds (5);
        Destroy (leafObject);
    }
