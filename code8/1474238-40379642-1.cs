    public class myclass()
    {
        public myclass(string variableName)
        {
            if (string.IsNullOrWhitespace(variableName)
            {
                throw new ArgumentNullException(nameof(variableName);
            }
            VariableName = variableName;
        }
        public string VariableName { get; private set; }
    }
    myclass theName;
    theName = new myclass(nameof(myclass));
