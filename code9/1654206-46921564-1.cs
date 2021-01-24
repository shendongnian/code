    public class Player_Data : NetworkBehaviour
    {
        private void Start()
        {    
            if (isLocalPlayer && !isServer)
            {
                CmdSendServerData();
            }
        }
        [Command]
        void CmdSendServerData()
        {            
            DisplayDataOnScreen("CmdSendServerData Called");          
        }
        [Server]
        void DisplayDataOnScreen(string data)
        {
            GameObject infoDisplayText = GameObject.Find("InfoDisplay");
            infoDisplayText.GetComponent<Text>().text += data + "\n";
        } 
    }
