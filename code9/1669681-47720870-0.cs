    public interface IFruit
    {
    }
    public interface IApple: IFruit
    {
    }
    public interface IFruits<T> where T : IFruit
    {
        T GetItem();
        void ProcessItem(T fruit);
        void Check();
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
    
        public void ProcessItem(T fruit)
        {
            throw new NotImplementedException();
        }
    }
    public interface IApples 
    {
        void MakeAppleJuice(IEnumerable<IApple> apples);
    }
    public class Apples : Fruits<IApple>, IApples
    {
        public void MakeAppleJuice(IEnumerable<IApple> apples)
        {
            throw new NotImplementedException();
        }
    }
    public class Context
    {
        public IApples Apples { get; set; }
    
        public Context()
        {
            this.Apples = new Apples();
        }
    
        public IFruits<IFruit> GetFruits<T>()
        {
            return null;
        }
        private void test()
        {
            //this.GetFruits<IFruit>().ProcessItem(
            //this.GetFruits<IApple>().ProcessItem(
            //this.Apples.MakeAppleJuice(            
        }
    }
    
    public class Foo
    {
        public void Main()
        {
            var context = new Context();
            Check(new IFruits<IFruit>[] { context.GetFruits<IApple>() });
        }
        public void Check(IEnumerable<IFruits<IFruit>> fruits) 
        {
            foreach (var fruit in fruits)
                fruit.Check();
        }
    }
