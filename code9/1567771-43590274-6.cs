    [Cmdlet("Greeting", "Get")]
    public class GetGreetingCommand : Cmdlet {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        protected override void ProcessRecord() {
            var greeter = new Greeter(Name);
            var greeting = greeter.SayHello();
            WriteObject(greeting);
        }
    }
