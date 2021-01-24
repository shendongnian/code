       [Command]
        public void CmdGameWon()
        {
            RpcGameEnd(this.netId);
        }
        
       [ClientRpc]
        public void RpcGameEnd(NetworkInstanceId nid)
        {
            if(this.isLocalPlayer && this.netId==nid){
                //Process win here
            }else{
                //Process lose here
            }
        }
    
