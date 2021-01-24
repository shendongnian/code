    using System;
    using System.Activities;
    namespace WorkflowDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                var app = new WorkflowApplication(new MyCustomActivity());
                var myExtension = new MyCommunicationExtension();
                myExtension.MyValueChanged += (s, e) => Console.WriteLine(myExtension.MyValue);
                app.Extensions.Add(myExtension);
                app.Run();
            
                Console.ReadKey();
            }
        }
        public class MyCommunicationExtension
        {
            public string MyValue { get; private set; }
            public event EventHandler<EventArgs> MyValueChanged;
            public void OnMyValueChanged(string value)
            {
                MyValue = value;
                MyValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public class MyCustomActivity : CodeActivity
        {
            protected override void Execute(CodeActivityContext context)
            {
                var extensionObj = context.GetExtension<MyCommunicationExtension>();
                if (extensionObj != null)
                {
                    extensionObj.OnMyValueChanged("Hello World");
                }
            }
        }
    }
