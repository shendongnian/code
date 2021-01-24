    interface IMachine
    {
        Cog cog { get; set; }
    }
    abstract class Machine : IMachine
    {
        Cog IMachine.cog { get; set; }
    }
    class BigMachine : Machine, IMachine
    {
        public BigCog cog { get; set; }
        Cog IMachine.cog
        {
            get { return cog; }
            set { cog = (BigCog) value; }
        }
    }
    class SmallMachine : Machine, IMachine
    {
        public SmallCog cog { get; set; }
        Cog IMachine.cog
        {
            get { return cog; }
            set { cog = (SmallCog)value; }
        }
    }
