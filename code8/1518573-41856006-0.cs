    public class GenericClass<T> : IGenericInterface<T> where T : WeirdType
    {
        public virtual T GiveT()
        {
            return default(T);
        }
        public virtual void TakeItBack(T data)
        {
            
        }
    }
    public class NonGenericClass1 : GenericClass<WeirdType1>, IGenericInterface<WeirdType>
    {
        public override WeirdType1 GiveT()
        {
            return new WeirdType1();
        }
        public void TakeItBack(WeirdType data)
        {
            Console.WriteLine("Got it back 1");
        }
        public override void TakeItBack(WeirdType1 data)
        {
            this.TakeItBack(data);
        }
        WeirdType IGenericInterface<WeirdType>.GiveT()
        {
            return GiveT();
        }
    }
    public class NonGenericClass2 : GenericClass<WeirdType2>, IGenericInterface<WeirdType>
    {
        public WeirdType2 GiveT()
        {
            return new WeirdType2();
        }
        public void TakeItBack(WeirdType data)
        {
            Console.WriteLine("Got it back 2");
            
        }
        public override void TakeItBack(WeirdType2 data)
        {
            this.TakeItBack(data);
        }
        WeirdType IGenericInterface<WeirdType>.GiveT()
        {
            return this.GiveT();
        }
    }
