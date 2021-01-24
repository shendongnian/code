    public class BigMachine
    {
        private readonly Machine _machine;
        public BigMachine(Machine machine)
        {
            _machine = machine;
        }
        public BigCog Cog
        {
            get { return (BigCog)_machine.cog; }
            set { _machine.cog = value; }
        }
    }
