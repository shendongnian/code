    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.UI;
    using System.Collections;
    
    public class GameRoomInfo : NetworkBehaviour
    {
        public Text txt_RedTotalFunds;
        public Text txt_BlueTotalFunds;
    
        public int oldRedFunds = 0;
        public int oldBlueFunds = 0;
    
        [SyncVar]
        public int redFunds;
        [SyncVar]
        public int blueFunds;
    
        void Update()
        {
            if (redFunds != oldRedFunds)
            {
                //txt_RedTotalFunds = GameObject.Find("txt_RedTotalFunds").GetComponent<Text>();
                txt_RedTotalFunds.text = "$" + redFunds;
                Debug.Log("Red - $" + redFunds);
                oldRedFunds = redFunds;
            }
    
            if (blueFunds != oldBlueFunds)
            {
                //txt_BlueTotalFunds = GameObject.Find("txt_BlueTotalFunds").GetComponent<Text>();
                txt_BlueTotalFunds.text = "$" + blueFunds;
                Debug.Log("Blue - $" + blueFunds);
                oldBlueFunds = blueFunds;
            }
        }
    }
