    public interface IFruitsBase<T> where T : Fruit
    {
        T GetItem();
        void ProcessItem(T fruit);
    }
    public interface IFruits
    {
        Fruit GetItem();
        void ProcessItem(Fruit fruit);
        void Check();
    }
    public class Fruits<T> : IFruitsBase<T>, IFruits where T : Fruit
    {
        public T GetItem()
        {
            return null;
        }
        public void ProcessItem(T fruit)
        {
        }
        public void Check()
        {
        }
        Fruit IFruits.GetItem()
        {
            throw new NotImplementedException();
        }
        void IFruits.ProcessItem(Fruit fruit)
        {
            ProcessItem((T)fruit);
        }
    }
    // no changes from here on
    public class Apples : Fruits<Apple>, IApples
    {
        public void MakeAppleJuice(IEnumerable<Apple> apples)
        {
        }
    }
    public class Fruit
    {
    }
    public class Apple : Fruit
    {
    }
    public interface IApples : IFruitsBase<Apple>, IFruits
    {
        void MakeAppleJuice(IEnumerable<Apple> apples);
    }
