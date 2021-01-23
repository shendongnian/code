    public class DrinkPictureBox : PictureBox
    {
        Drink drink = new Drink();
        public DrinkPictureBox(string Name, float Price, int Amount)
        {
            drink.Name = Name;
            drink.Price = Price;
            drink.Amount = Amount;
        }
    }
