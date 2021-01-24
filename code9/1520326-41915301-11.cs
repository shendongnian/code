    interface IParamConfigProvider
    {
        IParamConfig ParamConfig
        {
            get;
        }
    }
    
    public class ParamConfigTextBox : TextBox, IParamConfigProvider
    {
        private readonly paramConfig = new ParamConfig();
    
        [Category("_Vinci"),
        Description("The param config properties")]
        public ParamConfig ParamConfig
        {
            get { return paramConfig; }
        }
    
        IParamConfig IParamConfigProvider.ParamConfig
        {
            get { return ParamConfig; }
        }
    }
