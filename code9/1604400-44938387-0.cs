    class Combat
    {
      public int[] playerStats = new int[] { 25, 10};
      public int[] monsterStats = new int[] { 10, 10};
      string playerName;
      string monsterName;
      
      public Combat(string playerName) 
      {
        this.playerName = playerName;
        Slime s = new Slime();
        monsterName = s.Name;
      }
    }
