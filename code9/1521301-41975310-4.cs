    class Ingredient {
      int ID { get; set; }
      string Name { get; set; }
      string Percent { get; set; }
      List<string> Ingredients { get; set; }
      public Ingredient(int id, string name, string pct, List<string> ingredients) {
        ID = id;
        Name = name;
        Percent = pct;
        Ingredients = ingredients;
      }
      public override string ToString() {
        StringBuilder sb = new StringBuilder();
        sb.Append(ID + "\t" + Name + " " + Percent + Environment.NewLine);
        foreach (string s in Ingredients) {
          sb.Append("\t\t" + s + Environment.NewLine);
        }
        return sb.ToString();
      }
    }
