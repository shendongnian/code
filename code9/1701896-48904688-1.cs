    class Fruit
    {
    }
    class abstract RottenFruits<T> : Fruit where T : class
    {
        public T fruit; 
        bool isRotten { get; set; }
    }
