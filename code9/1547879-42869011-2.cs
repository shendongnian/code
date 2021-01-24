    interface IAnimal
    {
    }
    
    interface ICat
    {
        void MethodUniqueToCats();
    }
    class Cat<T> : IAnimal, ICat
    {
        public void MethodUniqueToCats()
        {
        }
    }
    
