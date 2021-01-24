    public class MakeForm<E> where E : FormType, new()
    {
        // Method which returns a new E
        public E MakeForm()
        {
            return new E();   // this works because of the new() constraint
        }
    }
