    public class Driver
    {
        public Driver(TextBox moduleName, TextBox dynamicNumber)
        {
            textBox_ModuleName = moduleName;
            textBox_DynamicNumber = dynamicNumber;
            textBox_ModuleName.DataBindings.Add("Text", this, "ModuleName");
            textBox_DynamicNumber.DataBindings.Add("Text", this, "DynamicNumber");
        }
        public string ModuleName { get; set; }
        public string DynamicNumber { get; set; }
        private TextBox textBox_ModuleName;
        private TextBox textBox_DynamicNumber;
    }
