    // invoked on client but executed on server
    [Command]
    private void CmdMakeServerSayHelloToClient()
    {
        RpcSayHelloToClient(); // invoked on server but executed on client
    }
    [ClientRpc]
    private void RpcSayHelloToClient()
    {
        Debug.Log("Hello from server."); // logged on client but not on server
    }
