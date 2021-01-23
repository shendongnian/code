    public class FruitBasket
    {
        public List<Fruit> FruitList { get; }
        public FruitBasket(List<Fruit> fruitList)
        {
            FruitList = fruitList;
        }
        public List<string> Project()
        {
            var result = new List<string>();
            foreach (var fruit in FruitList)
            {
                if (fruit is Apple)
                {
                    var apple = (Apple) fruit;
                    result.Add("This is a " + apple.Color + " " + apple.Name);
                }
                else if (fruit is Orange)
                {
                    var orange = (Orange) fruit;
                    result.Add("A " + orange.Name + " with type: " + orange.Type);
                }
                else
                {
                    result.Add("An unknown " + fruit.Name);
                }
            }
            return result;
        }
    }
