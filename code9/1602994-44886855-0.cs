    abstract class Cog { };
    class BigCog : Cog { }
    class SmallCog : Cog { }
    abstract class Machine
    {
        public Cog Cog
        {
            get
            {
                return GetCog();
            }
            set
            {
                SetCog(value);
            }
        }
        protected abstract Cog GetCog();
        protected abstract void SetCog(Cog value);
    }
    abstract class TypedMachine<T> : Machine where T: Cog
    {
        public T typeSafeCog;
        protected override Cog GetCog()
        {
            return typeSafeCog;
        }
        protected override void SetCog(Cog value)
        {
            if (value is T)
                typeSafeCog = (T)value;
            else
                throw new Exception("type error!");
        }
    }
    class BigMachine : TypedMachine<BigCog> { }
    class SmallMachine : TypedMachine<SmallCog> { }
    class Program
    {
        static void Main(string[] args)
        {
            var bigCog = new BigCog();
            var smallCog = new SmallCog();
            var bigMachine = new BigMachine();
            bigMachine.typeSafeCog = smallCog; // compile error
            bigMachine.typeSafeCog = bigCog; // ok
            Machine[] anyMachine = { new SmallMachine(), new BigMachine() };
            anyMachine[0].Cog = smallCog; // ok
            anyMachine[1].Cog = smallCog; // runtime exception
            anyMachine[1].Cog = bigCog; // ok
            Console.ReadKey();
        }
    }
