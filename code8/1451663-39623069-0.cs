    void Start()
    {
        if (photonView.isMine)
        {
            photonView.RPC("changeSprite", PhotonTargets.AllBuffered, null);
        }
    }
    
    [RPC]
    void changeSprite()
    {
        //Out Change Sprite code here
    }
