    public class ParamConfigTextBox : TextBox, IParamConfig
    {
        private readonly paramConfig = new ParamConfig();
    
        [DefaultValueAttribute(0), Category("_Vinci"),
        Description("Name of the variable in the BMS's memory associated with this control")]
        public string BmsParamName
        {
            get { return paramConfig.BmsParamName; }
            set { paramConfig.BmsParamName = value; }
        }
    
        // Conversion factor
        [DefaultValueAttribute(1),
         Description("To convert the BMS value to the value shown in this setting, divide by this factor"),
         Category("_Vinci")]
        public float ConversionFactor
        {
            get { return paramConfig.ConversionFactor; }
            set { paramConfig.ConversionFactor = value; }
        }
    }
