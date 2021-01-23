    class Bish
    {
        delegate void TestDelegate();
        delegate void TestDelegateWithParams(string parm);
        public void MMM()
        {
            TestDelegate tDel = () => { this.GetType().GetMethod("PrintMe").Invoke(this, null); };
            tDel.Invoke();
            TestDelegateWithParams tDel2 = (param) => { this.GetType().GetMethod("PrintMeWithParams").Invoke(this, new object[] { param }); };
            tDel2.Invoke("Test");
        }
        public void PrintMe()
        {
            Console.WriteLine("blah");
        }
        public void PrintMeWithParams(string param)
        {
            Console.WriteLine(param);
        }
    }
   
