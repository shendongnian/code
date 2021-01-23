        void Start (){
        	//first, grab the SkeletonRenderer on every version of the player. 
            //note that it should not be a local var now, but a field in the script
        	skeletonrenderer = GetComponent<SkeletonRenderer>();
        	
        	//now do the local player specific stuff
            if (isLocalPlayer) {
        
                //transmit the skin name to the other versions of the player
                CmdSendSkinRpc();
                        
                //then assign the skin to the local version of the player
                for(int z=0;z<SlotNames.Length;z++){
                    skeletonrenderer.skeleton.SetAttachment(SlotNames[z],GameController.control.skinName+AttachmentSuffix[z]);
                }
                GetComponent<PlayerManager> ().enabled = true;
                GetComponent<FollowCam> ().enabled = true;
            }
        }
        
        [Command]
        void CmdSendSkinRpc(){
        	RpcTransmitSkins(GameController.control.skinName);
        	Debug.Log("Transmitting Skin Named: " + GameController.control.skinName);
        }
        
        [ClientRpc]
        void RpcTransmitSkins(string TransmittedSkinName){
            if (!isLocalPlayer) {
        	    Debug.Log("Receiving Skin Named: " + TransmittedSkinName);
                for(int z=0;z<SlotNames.Length;z++){
                    skeletonrenderer.skeleton.SetAttachment(SlotNames[z],TransmittedSkinName+AttachmentSuffix[z]);
                }
            }
        }
