    public class MyWrapper{
    IntPtr myReference;
    public ObjectWrapper()
        {
            try
            {
               
                this.myReference = MyFactory();
                if (myReference == IntPtr.Zero)
                {
                   
                    throw "Error or something";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        //Path to dll
        [DllImport(lib_path)]
        private static extern IntPtr MyFactory();
        [DllImport(lib_path)]
        private static extern void SomeFunction(IntPtr toTrigger);
     }
