    public void OnPlayerRespawn(UnturnedPlayer player, Vector3 position, byte angle)
    {
        Invoke("Teleport", 2);
    }
    
    void Teleport(){
        player.Teleport(HQLocation1);
    }
