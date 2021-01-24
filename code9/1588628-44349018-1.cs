    public interface IFryCook
    {
        void Fry(FrenchFries fries);
    }
    public interface IGrillCook
    {
        void Grill(Burger burger);
    }
    public class FastFoodCook : IFryCook, IGrillCook
    {
        public void Fry(FrenchFries fries) { }
        public void Grill(Burger burger) { }
    }
