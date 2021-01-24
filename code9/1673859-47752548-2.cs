    [Command]
    void CmdOnWeaponThrowed(GameObject obj)
    {
        var netId = obj.GetComponent<NetworkIdentity>();
        if (netId == null)
        {
            // component is missing.
            return;
        }
        NetworkServer.Spawn(obj, netId.assetId);
    }
