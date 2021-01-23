    static String input = "JOIN GooGle | × ,,. ¬ hiring !HOteL, it is ++ !!free!! ,, ..!community;;+_";
    static Regex charOnly = new Regex("[^a-zA-Z ]");
    static Regex extarSpaces = new Regex(@"\s{2,}");
    static List<String> bannedWords = new List<String> { "join", "hiring", "hotel", "free", "community" };
    static void Main(string[] args) {
      string originalString = charOnly.Replace(input, "");
      originalString = extarSpaces.Replace(originalString, " ");
      originalString = originalString.ToLower();
      string[] splitArray = originalString.Split(' ');
      int count = 0;
      for (int i = 0; i < splitArray.Length; i++) {
        if (splitArray[i] != null) {
          if (bannedWords.Contains(splitArray[i].ToString())) {
            count++;
            Console.WriteLine("Banned: " + splitArray[i].ToString());
          }
        }
      }
      Console.WriteLine("originalString: " + originalString);
      Console.WriteLine("splitArray Size: " + splitArray.Length);
      Console.WriteLine("Banned Words in string = " + count);
      Console.ReadKey();
    }
