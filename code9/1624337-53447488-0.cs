    [Designer(typeof(UiPath.Core.Activities.Design.LogDesigner))]
    public class LogMessage : CodeActivity, IRegisterMetadata
    {
        [Category("Input")]
        public UiPath.Core.Activities.CurentLogLevel Level { get; set; }
    
        [Category("Input")]
        public InArgument<System.String> Message { get; set; }
    
        [Category("Input")]
        public InArgument<System.String> LogFilePath { get; set; }
