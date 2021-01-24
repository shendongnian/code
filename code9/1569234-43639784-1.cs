    enum Sport { Tennis, Golf }      
    public abstract class Player 
    {
      public string Name { get; set; }
      public DateTime Birthday { get; set; }
      public abstract Sport Sport { get; }
      public Player(string name, DateTime birthday) 
      {
        this.Name = name;
        this.Birthday = birthday;
      }
    }
