    using UnityEngine;
    
    public class RPC : Photon.PunBehaviour
    {
        public static RPC singleton;
    
        private void Awake()
        {
            if(singleton != null && singleton != this)
                Destroy(this);
            singleton = this;
        }
        //Called by someone who wants to set the score
        public void CallSetScore(sbyte score)
        {
            this.photonView.RPC("SetScore", PhotonTargets.All, score);
        }
        [PunRPC]
        public void SetScore(sbyte score)
        {
            //Do something with the score
        }
    }
