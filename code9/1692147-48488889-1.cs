    public class Item {
       private string reference = string.Empty;
       private string name = string.Empty;
       private double price = 0.0;
       private double tva = 0.0;
       //initialize all properties
       public Item(string reference, string name, double price, double tva)
        {
            this.reference = reference;
            this.name = name;
            this.price = price;
            this.tva = tva
        }
        //use this one to only set reference and name
        public Item(string reference, string name)
        {
            this.reference = reference;
            this.name = name;
        }
    }
