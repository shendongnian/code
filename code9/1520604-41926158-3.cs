    var jsonStr = "{ " +
                          "  \"game_count\": 119, " +
                          "  \"games\": [ " +
                          "      { " +
                          "          \"appid\": 3920, " +
                          "          \"playtime_forever\": 0 " +
                          "      }, " +
                          "      {                                 " +
                          "          \"appid\": 4000,              " +
                          "          \"playtime_forever\": 278     " +
                          "      }]                                 " +
                          "  }";
    var response = JsonConvert.DeserializeObject<Result>(jsonStr);
    foreach (var game in response.Gmaes)
    {
        Console.WriteLine(game.PlayTime);
    }
    Console.ReadKey();
