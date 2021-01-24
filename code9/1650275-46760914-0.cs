    public enum Opcode : long 
    {
        Add = 0L,
        Subtract = 1L,
        ...
    }
    public class Instruction 
    {
        public Opcode Opcode { get; }
        public Instruction(Opcode opcode)
        {
            if (is32Bit && ((long)opcode) > int.MaxValue)
                throw new InvalidOperationException();
            Opcode = opcode;
        }
    }
