    string like = "%A%C%";
    string source = "A B C";
    if (Regex.IsMatch(source, LikeToRegular(like))) {
      Console.Write("Matched");
    }
   
