    [Cmdlet("Load" , "Item", DefaultParameterSetName="Item")]
    public class LoadCommand : Cmdlet
    {
        private string assembly;
     
        [Parameter(Mandatory=true, ValueFromPipeline=true, ParameterSetName="Item", Position=0, HelpMessageResourceId="LoadCmdlet_Item")]
        public string Assembly
        {
            get { return assembly; }
            set { assembly = value; }
        }
     
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
     
            if (File.Exists(assembly))
            {
                WriteObject(Assembly.LoadFrom(fileName));
                return;
            }
        }
    
    }
