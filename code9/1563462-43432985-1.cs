    public static async Task<List<Character>> LoadCharacterData(Client player)
    {
      var filter = new BsonDocument("NameOfTable", player.Name);
      var characters = await DatabaseManager.Characters.Find(filter).ToListAsync();
      List<Character> result = new List<Character>();
      foreach (var character in characters)
      {
        result.Add(new Character
          {
            Name = character.Name,
            Surname = character.Surname
          }
        );
      }
      return result;
    }
