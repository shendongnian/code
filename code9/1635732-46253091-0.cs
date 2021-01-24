    [Cmdlet(VerbsCommon.Get, "Numbers")]
    public class GetNumbersCmdlet: Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("1");
            WriteObject("2");
            WriteObject("3");
            WriteObject("4");
            WriteObject("5");
        }
    }
