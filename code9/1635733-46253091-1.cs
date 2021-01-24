    [Cmdlet(VerbsCommon.Get, "Numbers")]
    public class GetNumbersCmdlet: Cmdlet
    {
        protected override void BeginProcessing()
        {
            var list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            WriteObject(results, true);
        }
    }
