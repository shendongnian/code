    enum Sport { Tennis, Golf }      
    public abstract class Player 
    {
      // Consider making Name and Birthday get-only as well.
      // Is there any situation in which they change after construction?
      // If not, then *don't allow them to change*!
      public string Name { get; set; }
      public DateTime Birthday { get; set; }
      public abstract Sport Sport { get; }
      public Player(string name, DateTime birthday) 
      {
        this.Name = name;
        this.Birthday = birthday;
      }
    }
