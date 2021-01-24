    public class Player_Data : NetworkBehaviour
    {
        private void Start()
        {
            if (!isLocalPlayer)
            {
                return;
            }
            CmdSendServerData();
        }
        [Command]
        void CmdSendServerData()
        {
            if (!isServer)
            {
                DisplayDataOnScreen("CmdSendServerData Called");
            }   
        
        }
        [Server]
        void DisplayDataOnScreen(string data)
        {
            GameObject infoDisplayText = GameObject.Find("InfoDisplay");
            infoDisplayText.GetComponent<Text>().text += data + "\n";
        } 
    }
