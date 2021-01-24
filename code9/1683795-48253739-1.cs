     void OnTriggerEnter (Collider other)
    { 
        if(other.gameobject.tag == "Player")
        {
          // animation code
          Debug.Log("animation started..."); 
        }
    }
