    float fTime = 0.1f
    float fTimer = 0;
    int iCollisionCounter;
    if(collision){
       if(fTimer > 0) iCollisionCounter++;
       if(iCollisionCounter >= 5) //Character is stuck
       fTimer = fTime;
    }
    Void Update(){
        fTimer -= time.deltaTime;
    }
