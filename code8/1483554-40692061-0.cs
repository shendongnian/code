    void OnTriggerEnter ( Collider other) {
    
        if (other.gameObject.tag == "leaf1")
        {
            IEnumerator coroutine = LeafDestruction(other.gameObject);
            StartCoroutine (coroutine);
        }
    }
    IEnumerator LeafDestruction(GameObject toDestroy){
        yield return new WaitForSeconds (5);
        Destroy (toDestroy);
    }
