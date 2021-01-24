    public class PlayerController : NetworkBehaviour
    {
    	[Command]
    	void CmdSwitchtoAk()
    	{
    		RpcSwitchtoAk();
    	}
    
    	[ClientRpc]
    	void RpcSwitchtoAk()
    	{
    		changeWeapon(1);
    		CurrentWeaponstr = "Ak47";
    	}
    }
