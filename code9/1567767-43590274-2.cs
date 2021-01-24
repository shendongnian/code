    [Cmdlet("GoodBye", "Get")]
    public class GetGoodByeCommand : Cmdlet {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
    
        protected override void ProcessRecord() {
            var greeter = new Greeter(Name);
            var goodBye = greeter.SayGoodBye();
            WriteObject(goodBye);
        }
    }
