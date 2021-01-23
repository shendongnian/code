    using UnityEngine;
    using UnityEngine.Networking;
    
    public class RaycastExample : NetworkBehaviour
    
        void ToggleSwitch()
            {
                RaycastHit hit;
                //Use raycasting to find switch
                if (Physics.Raycast(transform.position, transform.forwards, out hit, 5.0f))
                {
                    if (hit.GetComponent<LightSwitch>())
                    {
                        //Send the command to toggle the switch of the server, passing in the LightSwitch gameobject as the parameter
                        CmdToggleSwitch (hit.transform.gameObject);
                    }
                }
        }
    
        //This will be run on the server version of our player
        [Command]
        void CmdToggleSwitch (GameObject switch) //switch must have network identity component
        {
          //Set the switch state on the server
          //Server light switch will need some way to notify the clients of the change. RPC or SyncVar.
          switch.GetComponent<LightSwitch>().ToggleMethod();
        }
