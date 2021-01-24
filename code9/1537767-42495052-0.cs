    public class AmmuNation : Script
    {
        Player Ply = new Player();
    
        public void Test()
        {
            API.consoleOutput(Player.CharacterList[sender.name].charname);
        }
    }
