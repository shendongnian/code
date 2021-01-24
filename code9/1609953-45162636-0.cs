    public class SubVariable1
        {
            public string DataType { get; set; }
            public string Unit { get; set; }
            public string High { get; set; }
            public string Low { get; set; }
            public string Nominal { get; set; }
        }
    
        public class SubVariable2
        {
            public string DataType { get; set; }
            public string Unit { get; set; }
            public string High { get; set; }
        }
    
        public class Variable1
        {
            public SubVariable1 SubVariable1 { get; set; }
            public SubVariable2 SubVariable2 { get; set; }
        }
    
        public class Variable2
        {
            public string DataType { get; set; }
            public string Unit { get; set; }
            public string Max { get; set; }
            public string Low { get; set; }
            public string LowLow { get; set; }
        }
    
        public class Variables
        {
            public Variable1 Variable1 { get; set; }
            public Variable2 Variable2 { get; set; }
        }
    
        public class PropertyName
        {
            public string DataType { get; set; }
            public string Value { get; set; }
        }
    
        public class ConstantProperty
        {
            public PropertyName PropertyName { get; set; }
        }
    
        public class Properties
        {
            public ConstantProperty ConstantProperty { get; set; }
        }
    
        public class RootObject
        {
            public string model { get; set; }
            public string name { get; set; }
            public Variables variables { get; set; }
            public Properties properties { get; set; }
        }
    
        class Stackoverflow
        {
            static void Main(string[] args)
            {
    
                string strJSONData = "Your JSON Data";// Either read from string of file source
                System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<RootObject> objRootObjectList = jsSerializer.Deserialize<List<RootObject>>(strJSONData);
    Console.ReadLine();
            }
        }
