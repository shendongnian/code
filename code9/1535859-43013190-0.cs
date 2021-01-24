       [SyncVar]//server to client. sync this variable name across all clients
       public string localPlayerName = "Player";
       void OnGUI()
        {
            if (isLocalPlayer)
            {
                localPlayerName = GUI.TextField(new Rect(0, 0, 100, 20), localPlayerName);
    
                if (GUI.Button(new Rect(110, 0, 100, 20), "Name"))
                {
                    CmdUpdateLocalPlayerName(localPlayerName);
    
                }
            }
        }
    
        [Command]//client to server
        void CmdUpdateLocalPlayerName(string userName)
        {
            localPlayerName = userName;
        }
