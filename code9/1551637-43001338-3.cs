    public abstract class Countable : Ingredient 
    {
       protected abstract int Count { get; set; }
    }
    
    public abstract class Qantable : Ingredient 
    {
        protected abstract decimal Quantity { get; set; }
    }
