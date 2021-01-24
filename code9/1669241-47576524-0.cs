    public class Proccessor
    {
        //it's OK here
        public Proccessor(Action<INode<string>> do1Action)
        {
        }
        private Proccessor() 
        {
            // a private constructor for the CreateProcessor static method
        }
        
        public static Proccessor CreateProccessor<T>(Action<T><INode<T>> do2Action)
        {
            var proccessor = new Proccessor();
            // invoke action here
        }
    }
