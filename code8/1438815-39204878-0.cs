    public void OnPlayerRespawn(UnturnedPlayer player, Vector3 position, byte angle)
    {    
        Invoke("TeleportPlayer", 5);
    }
    private void TeleportPlayer()
    {
        player.Teleport(HQLocation1);
    }
