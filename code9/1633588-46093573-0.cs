    partial class PhoneRecord : ICloneable
    {
        public object Clone()
        {
            return new PhoneRecord()
            {
                CostCode = this.CostCode,
                //+ all other properties...
            }
        }
    }
