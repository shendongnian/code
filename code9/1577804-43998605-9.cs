    public class PreferredDayInstruction : Instruction
    {
        public PreferredDayInstruction(string date)
            : base(InstructionType.PreferredDay, date) { }
        public override bool IsValid(string data)
        {
            string[] formats = {"dd.MM.yyyy", "d.MM.yyyy",
                                "dd.MM.yy", "d.MM.yy"};
            try
            {
                data = data.Replace('/', '.').Replace('-', '.');
                var dateparts = data.Split('.');
                DateTime date = new DateTime(Convert.ToInt32(dateparts[2]),
                                             Convert.ToInt32(dateparts[1]),
                                             Convert.ToInt32(dateparts[0]));
                //DateTime.ParseExact(data, formats, null, System.Globalization.DateTimeStyles.AssumeLocal);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
        public class ServicePointInstruction : Instruction
    {
        public ServicePointInstruction(string data)
            : base (InstructionType.ServicePoint, data) { }
        public override bool IsValid(string data)
        {
            return ServicePointBarcodeValidator.Validate(data); 
        }
    }
        public class NeighbourInstruction : Instruction
    {
        public NeighbourInstruction(string data) :
            base(InstructionType.Neighbour, data) { }
        public override bool IsValid(string data)
        {
            return data.Length <= 70;
        }
    }
