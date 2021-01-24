    private List<string> validWords = new List<string>{"hallway","dance room"};
    private string GetInput()
    {
      var response = string.Empty;
      while (true)
        {
          response = Console.ReadLine();
          if (validWords.Contains(response))
            {
              break;
            }
        }
        return response;
    }
    private void ProcessInput(string response)
    {
       //switch statements go here
    }
