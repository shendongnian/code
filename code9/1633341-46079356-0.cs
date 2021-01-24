    interface IMachine
    {
       string MachineId { get; set; }
       StateObject State { get; set; }
    }
    
    class Machine : IMachine
    {
       public State { 
        get { return [Current State]; } 
        set { [Current State] = value; }
       }
    }
    static class MachineCollection
    {
        pricate List<IMachine> _Machines;
        public static List<IMachine> Machines
        {
            get
            {
                if (_Machines == null)
                {
                    // Instantiate Machines here
                }
            }
        }
    }
