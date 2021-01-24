    public class ParamConfig : IParamConfig
    {
        private string bmsParamName = ""; 
        [DefaultValueAttribute(0),
        Description("Name of the variable in the BMS's memory associated with this control")]
        public string BmsParamName
        {
            get { return bmsParamName; }
            set { bmsParamName = value; }
        }
    
        // Conversion factor
        private float conversionFactor = 1F;
        [DefaultValueAttribute(1),
         Description("To convert the BMS value to the value shown in this setting, divide by this factor")]
        public float ConversionFactor
        {
            get { return conversionFactor; }
            set { conversionFactor = value; }
        }
    }
