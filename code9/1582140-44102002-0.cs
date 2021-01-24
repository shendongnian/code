    namespace Application
    {
        public class TestClass
        {
            int _a;
        
            public void Print()
            {
                Console.WriteLine(_a);
            }
        
            public TestClass(int a)
            {
                this._a = a;
            }
        }
    }
---
    Lua lua = new Lua();
    lua.LoadCLRPackage();
    lua.DoFile("script.lua");
