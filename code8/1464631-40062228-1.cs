    void Main()
    {
        var x = new Action(0x1AF0F0, 0x01, 0x20, OpCode.BX_LR); //Return 1. (true)
        Console.WriteLine(x);
    }
    
    public class Action
    {
        public Action(int address, params OpCode[] bytes)
        {
            Address = address;
            Bytes = OpCode.Flatten(bytes);
        }
    
        public int Address { get; set; }
        public byte[] Bytes { get; set; }
    }
    
    public class Mod
    {
        public Mod(string name, List<Action> actions)
        {
            Name = name;
            Actions = actions;
        }
    
        public string Name { get; set; }
        public List<Action> Actions { get; set; }
    }
    
    public class OpCode
    {
        private byte[] _value;
    
        private OpCode(byte[] value)
        {
            _value = value;
        }
    
        public static byte[] BX_LR = {0x70, 0x47};
    
        public static implicit operator OpCode (byte value)
        {
            return new OpCode(new []{value});
        }
    
        public static implicit operator OpCode (byte[] value)
        {
            return new OpCode(value);
        }
    
        public static byte[] Flatten (OpCode[] opCodes)
        {
            var result = new List<byte>(opCodes.Length);
            foreach (var opCode in opCodes)
            {
                result.AddRange(opCode._value);
            }
            return result.ToArray();
        }
    }
