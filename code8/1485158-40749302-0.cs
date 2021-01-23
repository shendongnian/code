    /// <summary>
    /// just a stub to demonstrate the model
    /// </summary>
    internal class Machine
    {
        public string ReadData() { return "this is data"; }
        public void WriteData(string data) { Console.WriteLine(data); }
    }
    internal interface IMachineDataAccessor
    {
        string Read();
        void Write(string data);
    }
    class LinkClass : IMachineDataAccessor
    {
        protected Machine _machine;
        public LinkClass(Machine machine)
        {
            _machine = machine;
        }
        public void DoMyWork()
        {
            // insert work somewhere in here.
            string dataFromMachine = Read();
            Write("outbound data");
        }
        public string Read()
        {
            return _machine.ReadData();
        }
        public void Write(string data)
        {
            _machine.WriteData(data);
        }
    }
    class PersistentClass
    {
        IMachineDataAccessor _machineImpl;
        public PersistentClass(IMachineDataAccessor machineAccessImplementation) 
        {
            _machineImpl = machineAccessImplementation;
        }
        public void DoMyWork()
        {
            string dataFromMachine = _machineImpl.Read();
            // insert work here.  Or anywhere, actually..
            _machineImpl.Write("outbound data");
        }
    }
    class StateClass
    {
        IMachineDataAccessor _machineImpl;
        public StateClass(IMachineDataAccessor machineAccessImplementation) 
        {
            _machineImpl = machineAccessImplementation;
        }
        public void DoMyWork()
        {
            string dataFromMachine = _machineImpl.Read();
            // insert work here.  Or anywhere, actually..
            _machineImpl.Write("outbound data");
        }
    }
    static void Main(string[] args)
    {
        LinkClass link = new LinkClass(new Machine());
        PersistentClass persistent = new PersistentClass(link as IMachineDataAccessor);
        StateClass state = new StateClass(link as IMachineDataAccessor);
        persistent.DoMyWork();
        state.DoMyWork();
        link.DoMyWork();
    }
