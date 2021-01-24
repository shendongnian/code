    abstract class Machine<T> where T:Cog
    {
        public virtual T cog { get; set; }
    }
    class BigMachine : Machine<BigCog>
    {
        
    }
