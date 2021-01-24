    namespace MyClass
    {
        public class Class1 : Common.IMyInterface
        {
            public int MyNumber { get; set; } = 6;
    
            public int GetMyNumber()
            {
                return MyNumber;
            }
        }
    }
    private void Form1_Load(object sender, EventArgs e)
            {
                string fName = @".....\MyClass.dll";
    
                Assembly decoupledAssembly = Assembly.LoadFrom(fName);
                if (decoupledAssembly != null)  //All Good
                {
                    Type t = decoupledAssembly.GetType("MyClass.Class1");
                    //Good here too, it finds it just fine.
                    Common.IMyInterface mi = (Activator.CreateInstance(t) as Common.IMyInterface);
                    //Now it works.
                    if (mi != null)
                        MessageBox.Show(mi.GetMyNumber().ToString());                    
                }
            }
