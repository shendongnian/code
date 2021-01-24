    public interface IFruits<out T> where T : IFruit
    {
        T GetItem();
        void ProcessItem(IFruit fruit);
        void Check();
    }
    public interface IApples : IFruits<IApple>
    {
        void MakeAppleJuice(IEnumerable<IApple> apples);
    }
    public class Fruits<T> : IFruits<T> where T : IFruit
    {
        public void Check()
        {
            throw new NotImplementedException();
        }
        public T GetItem()
        {
            throw new NotImplementedException();
        }
        public void ProcessItem(IFruit fruit)
        {
            if (fruit is T)
            {
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
    public class Apples : Fruits<IApple>, IApples
    {
        public void MakeAppleJuice(IEnumerable<IApple> apples)
        {
            // Do the juice
        }
    }
