    private static string[] GetGroceryList() {
      Console.WriteLine("Today we will be creating a shopping list.\n\rPlease enter a list of items separated by commas.");
      string userList = Console.ReadLine();
      if (userList != "") {
        string[] userArray = userList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < userArray.Length; i++) {
          userArray[i] = userArray[i].Trim();
        }
        return userArray;
      }
      else {
        return new string[0];
      }
    }
