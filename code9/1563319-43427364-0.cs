    public class User 
    {
      public string Name{get;set;}
      public string SurName{get;set;}
    }
    
    public static List<User> Users {get;set;}
    public static async Task LoadCharacterData(Client player)
    {
      //*Snip*
      foreach(var character in character)
        Users.Add(new User {Name = character.Name; SurName = character.Surname;}
    }
