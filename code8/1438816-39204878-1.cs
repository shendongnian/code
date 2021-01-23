    public void OnPlayerRespawn(UnturnedPlayer player, Vector3 position, byte angle)
    {    
        StartCoroutine(TeleportPlayer(some parameters));
    }
    private IEnumerator TeleportPlayer(some parameters)
    {
        // wait before doing other stuff
        yield return new WaitForSeconds(5);
        player.Teleport(HQLocation1);
    }
