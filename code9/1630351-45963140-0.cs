    public class DuckFactory
    {
        public ExpandoObject GetDuck()
        {
            dynamic duck = new ExpandoObject();
            duck.Name = "Fauntleroy";
            return duck;
        }
    }
