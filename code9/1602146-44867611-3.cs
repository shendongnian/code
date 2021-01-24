    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.UI;
    using System.Collections;
    
    public class Player : NetworkBehaviour 
    {
        public enum PlayerColor
        { 
            Red, 
            Blue
        };
    
        //used to update the right variables (Blue player updates blueFunds and Red player updates redFunds)
        [SyncVar]
        PlayerColor playerColor;
    
        static int colorSelect = 0;
    
        void Start()
        {
            if(isServer) 
            {
                // the server selects the player color when created
                switch(colorSelect % 2)
                {
                    case 0:
                        playerColor = PlayerColor.Red;
                        break;
                    case 1:
                        playerColor = PlayerColor.Blue;
                        break;
                }
    
                colorSelect++;
            }
        }
    
        void Update()
        {
            if (!isLocalPlayer)
                return;
    
            if (hasAuthority && Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                Cmd_UpdateAdd(10);
            }
        }
    
        // Button
        void btn_Update()
        {
            if (!hasAuthority)
                return;
            Cmd_Update(0);
        }
    
        void btn_Add()
        {
            if (!hasAuthority)
                return;
            Cmd_Update(10);
        }
    
    
        [Command]
        public void Cmd_Update(int _value)//The command updates the GameRoomInfo variables according to the player color
        {
            switch (playerColor)
            {
                case PlayerColor.Red:
                    FindObjectOfType<GameRoomInfo>().redFunds = _value;
                    break;
                case PlayerColor.Blue:
                    FindObjectOfType<GameRoomInfo>().blueFunds = _value;
                    break;
                default:
                    break;
            }
        }
    
        [Command]
        public void Cmd_UpdateAdd(int _value)
        {
            switch (playerColor)
            {
                case PlayerColor.Red:
                    FindObjectOfType<GameRoomInfo>().redFunds += _value;
                    break;
                case PlayerColor.Blue:
                    FindObjectOfType<GameRoomInfo>().blueFunds += _value;
                    break;
                default:
                    break;
            }
        }
    }
