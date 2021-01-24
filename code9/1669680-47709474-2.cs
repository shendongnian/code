    public class Context
    {
        public IApples Apples { get; set; }
        public IBananas Bananas { get; set; }
        public Context()
        {
            Apples = new Apples();
        }
        public IFruits<T> GetFruits<T>() where T : IFruit
        {
            return new Fruits<T>();
        }
    }
