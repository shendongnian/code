    public class StringIdLengthRangeAttribute : ValidationAttribute
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public StringLengthRangeAttribute()
        {
           this.Minimum = 0;
           this.Maximum = int.MaxValue;
        }
        public override bool IsValid(object value)
        {
            string strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                int len = strValue.Length;
                return len >= this.Minimum && len <= this.Maximum;
            }
            return true;
        }
    }
