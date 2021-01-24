    void Main()
    {
        const string json = @"    { 
            'variableName': 'Current',
            'dataFormat': 'System.Double',
            'dataValue' : '1.2e3' //scientific notation
        }";
        var v = JsonConvert.DeserializeObject<Variable>(json);
        
        Console.WriteLine($"Value={v.VariableValue}, Type={v.VariableValue.GetType().Name}");
        // Value=1200, Type=Double
        // Note that it converted the string "1.2e3" to a proper numerical value of 1200.
        // And recognises that VariableValue is a Double instead of our declared Object.
    }
    
    public class Variable
    {
        // From JSON:
        public string VariableName { get; set; }
        public string DataFormat { get; set; }
        public string DataValue { get; set; }
    
        // Here be magic:
        public object VariableValue
        {
            get
            {
                /*  This assumes that 'DataFormat' is a valid .NET type like System.Double.
                    Otherwise, you'll need to translate them first.
                    E.g. "FLOAT" => "System.Single" 
                         "INT"   => "System.Int32", etc
                */
                var actualType = Type.GetType(DataFormat, true, true);
                return Convert.ChangeType(DataValue, actualType);
            }
        }
    }
    
