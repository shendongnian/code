     public abstract class Instruction
    {
        public InstructionType Type { get; private set; }
        public string Data { get; private set; } <---Type String
        public Instruction(InstructionType type, string data)
        {
            this.Type = type;
            this.Data = IsValid(data) ? data : string.Empty;
        }
        public abstract bool IsValid(string data); <--the rule.
    }
