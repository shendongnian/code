    public class OrgName
    {
        private string _value;
        private string Value
        {
            get { return _value; }
            set
            {
                bool isAllZeros = value?.All(x => x == '0') ?? false;
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
