      List<string> abc = new List<string>(); // List<string>, not StringBuider
      abc.Add("Hi.");
      Fun(2, abc);
      ...
      void Fun(int i, IList<string> abc) {
        if (abc.Any())
          abc.Add("its me.");
      }
      ...
      Console.WriteLine(string.Join(" ", abc
        .Select((item, index) => $"{index + 1}){item}"))); 
