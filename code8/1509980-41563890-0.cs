    public class OrgName
    {
        private string _value;
        private string Value
        {
            get { return _value; }
            set
            {
                bool isAllZeros = value.Where(x => char.IsDigit(x)).All(x => x == '0');
                if(isAllZeros)
                {
                    _value = string.Empty;
                }
                else
                {
                    _value = value;
                }
            }
        }
    }
