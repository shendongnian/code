    abstract class Machine
    {
        protected virtual Cog _cog { get; set; }
        public Cog cog
        {
            get { return this._cog; }
            set { this._cog = value; }
        }
    }
    class BigMachine: Machine
    {
        protected override Cog _cog
        {
            get { return base._cog; }
            set
            {
                if ( value != null && !(value is BigCog) )
                    throw new ArgumentException();
                base._cog = value;
            }
        }
        new public BigCog cog
        {
            get { return (BigCog)base._cog; }
            set { base._cog = value; }
        }
    }
