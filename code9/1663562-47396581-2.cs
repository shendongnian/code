    [Cmdlet(VerbsCommon.Invoke, "ThingWithAppObject"]
    [OutputType(typeof(Int32))]
    public class InvokeThingWithAppObject : MyCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0)]
        public AppObject InputObject {get; set;}
        protected override void ProcessRecord()
        {
            int result = InputObject.DoSomething(this);
            WriteObject(result);
        }
    }
