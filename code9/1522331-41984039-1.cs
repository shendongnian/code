    public void StoreGameState(GameState state)
    {
        using (BinaryWriter writer = new BinaryWriter(File.OpenWrite("./gamestate.bin")))
        {
            var formatter = new BinaryFormatter()
            formatter.Serialize(state, writer);
        }
    }
    public GameState RestoreGameState()
    {
        using (BinaryReader reader = new BinaryReader(File.OpenRead("./gamestate.bin")))
        {
            var formatter = new BinaryFormatter()
            return (GameState)formatter.Deserialize(reader);
        }
    }
