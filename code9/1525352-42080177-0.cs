    public class MyClass
    {
        private void AssertAutoFac()
        {
            var trace = new StackTrace();
            for (int i=2; i<trace.FrameCount; i++)  //Start with i=2, skipping last two stack entries, which will be internal to this class anyway
            { 
                var dll = trace.GetFrame(i).GetMethod().DeclaringType.Assembly.FullName;
                if (dll == "AutoFac") return;  //You might have to experiment to get this comparison just right
            }
            throw new InvalidOperationException("You must instantiate using AutoFac!");
        }
        public MyClass()
        {
            AssertAutoFac();
        }
    }
