    public void OnPlayerDownloaded(Client player)
    {
        var task = CharacterController.LoadCharacterData(player);
        task.Wait(); // <---
        Console.WriteLine("TEST: " + CharacterController.Characters[0].Name + CharacterController.Characters[0].Surname);
    }
