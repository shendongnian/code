    static string ingredients = "Water, Bulgur Wheat(29%), Sweetened Dried Cranberries(5%) (Sugar, Cranberries)," +
                                  " Sunflower Seeds(3%), Onion(3%), Green Lentils(2%), Palm Oil, Flavourings (contain Barley)," +
                                  " Lemon Juice Powder(<2%) (Maltodextrin, Lemon Juice Concentrate)," + 
                                  " Ground Spices(<2%) (Paprika, Black Pepper, Cinnamon, Coriander, Cumin, Chilli Powder, Cardamom, Pimento, Ginger)," + 
                                  " Dried Herbs(<2%) (Coriander, Parsley, Mint), Dried Garlic(<2%), Salt, Maltodextrin, Onion Powder(<2%)," + 
                                  " Cumin Seeds, Dried Lemon Peel(<2%), Acid(Citric Acid)";
    static List<Ingredient> allIngredients;
    static void Main(string[] args) {
      allIngredients = ParseString(ingredients);
      foreach (Ingredient curIngredient in allIngredients) {
        Console.Write(curIngredient.ToString());
      }
      Console.ReadLine();
    }
    private static List<Ingredient> ParseString(string inString) {
      List<Ingredient> allIngredients = new List<Ingredient>();
      string temp = ReplaceCommaBetweenParens(ingredients);
      string[] allItems = temp.Split(',');
      int count = 1;
      foreach (string curItem in allItems) {
        if (curItem.Contains("(")) {
          allIngredients.Add(ParseItem(curItem, count));
        }
        else {
          allIngredients.Add(new Ingredient(count, curItem.Trim(), "", new List<string>()));
          //Console.WriteLine(count + "\t" + curItem.Trim());
        }
        count++;
      }
      return allIngredients;
    }
    private static Ingredient ParseItem(string item, int count) {
      string pct = "";
      List<string> items = new List<string>();
      int firstParenIndex = item.IndexOf("(");
      //Console.Write(count + "\t" + item.Substring(0, firstParenIndex).Trim());
      Regex expression = new Regex(@"\((.*?)\)");
      MatchCollection matches = expression.Matches(item);
      bool percentPresent = true;
      foreach (Match match in matches) {
        if (match.ToString().Contains("%")) {  // <-- if the string between parenthesis does not contain "%" - move to next line, otherwise print on same line
          //Console.WriteLine(" " + match.ToString().Trim());
          pct = match.ToString().Trim();
          percentPresent = false;
        }
        else {
          if (percentPresent) {
            //Console.WriteLine();
           }
          items = GetLastItems(match.ToString().Trim());
        }
      }
      return new Ingredient(count, item.Substring(0, firstParenIndex).Trim(), pct, items);
    }
    
    private static List<string> GetLastItems(string inString) {
      List<string> result = new List<string>();
      string temp = inString.Replace("(", "");
      temp = temp.Replace(")", "");
      string[] allItems = temp.Split('-');
      foreach (string curItem in allItems) {
        //Console.WriteLine("\t\t" + curItem.Trim());
        result.Add(curItem.Trim());
      }
      return result;
    }
    
    private static string ReplaceCommaBetweenParens(string inString) {
      string pattern = @"(?<=\([^\)]*)+,(?!\()(?=[^\(]*\))";
      return Regex.Replace(inString, pattern, "-");
    }
  
