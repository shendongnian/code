    void OnTriggerEnter(Collider other){
        if (other.tag == "Finish"){
            Debug.Log("hai perso!");
            endGame = true;
        }
    }
