    public class MyClass
    {
        private void AssertAutoFac()
        {
            var trace = new StackTrace();
            for (int i=2; i<trace.FrameCount; i++)  //Start with i=2, skipping last two stack entries, which will be internal to this class anyway
            { 
                var method = trace.GetFrame(i).GetMethod();
                if (method.Name == "Resolve") 
                {
                    var dll = method.DeclaringType.Assembly.FullName;
                    if (dll == "Autofac, Version=1.4.4.561, Culture=neutral, PublicKeyToken=17863af14b0044da") return;  
                }
            }
            throw new InvalidOperationException("You must instantiate using AutoFac!");
        }
        public MyClass()
        {
            AssertAutoFac();
        }
    }
