    public class ClassUnderTest
        {
            
            public bool foo()
            {
                if(Dependecy.FindWindow("bla","bla") == null)
                {
                    throw new Exception();
                }
                return true;
            }
        }
    
    public class Dependecy
    {//imported method from dll
         [DllImport("user32.dll")]
         public static extern IntPtr FindWindow(string name, string windowName);
     }
    
            [TestMethod]
            public void TestMethod1()
            {
                //setting a mocked behavior for when the method will be called
                Isolate.WhenCalled(() => Dependecy.FindWindow("", "")).WillReturn(new IntPtr(5));
    
                ClassUnderTest classUnderTest = new ClassUnderTest();
                var res = classUnderTest.foo();
    
                Assert.IsTrue(res);
            }
