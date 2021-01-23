     string keyWord;
     keyWord = Console.ReadLine();
     foreach (string[] item in loggbok)
     {                                       
        if (checkItem(item)) {
            for(int i = 0; i < item.Length; i++){
              Console.WriteLine(item[i]);
            }
        }
     }
    public bool checkItem(string[] item, string keyWord) {
      foreach(var s in item) {
         if(s.Contains(keyWord))
             return true;
      }
      return false;
    }
