    abstract class Machine
    {
        public virtual Cog cog { get; set; }
    }
    abstract class BigMachineBase: Machine
    {
        public override Cog cog
        {
            get { return base.cog; }
            set
            {
                if ( value != null && !(value is BigCog) )
                    throw new ArgumentException();
                base.cog = value;
            }
        }
    }
    class BigMachine: BigMachineBase
    {
        new public BigCog cog
        {
            get { return (BigCog)base.cog; }
            set { base.cog = cog; }
        }
    }
