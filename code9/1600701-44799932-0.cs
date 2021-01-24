    public class Item
    {
       public Item(string x){
        if (!int.TryParse(value, out temp))
            {
                throw new ArgumentException("Give me an int to parse");
            }
            else
            {
                Prop1 = temp;
            }
         }
    }
