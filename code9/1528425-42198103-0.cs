    void Start() {
              //Invokes the method methodName in time seconds,
              //then repeatedly every repeatRate seconds.
              InvokeRepeating("CheckPlayers", 2.0f, 0.3f);
        }
    
 
    public void CheckPlayers(){
           //assign player in the player list
           playersList= GameObject.FindGameObjectsWithTag ("Player");
          //now playersList contains all player, do what you want with it
    
    }
