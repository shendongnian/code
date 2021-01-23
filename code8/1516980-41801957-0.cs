    public enum PizzaSize
    {
        Small,
        Medium,
        Large
    }
    public struct PizzaDetails
    {
        public PizzaDetails(int choice, PizzaSize size, double price)
        {
            Choice = choice;
            Size = size;
            Price = price;
        }
        int Choice { get; set; }
        PizzaSize Size { get; set; }
        double Price { get; set; }
    }
    public class PizzaChoice
    {
        public PizzaDetails GetPizzaDetails(int choice)
        {
            switch (choice)
            {
                case 1:
                    return new PizzaDetails(choice, PizzaSize.Small, 5);
                case 2:
                    return new PizzaDetails(choice, PizzaSize.Medium, 7);
                case 3:
                    return new PizzaDetails(choice, PizzaSize.Large, 10);
                default:
                    throw new ArgumentOutOfRangeException("Invalid choice", nameof(choice));
            }
        }
    }
 
