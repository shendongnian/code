    class MethodInvoker
    {
        delegate void TestDelegate();
        public void fun()
        {
            Console.WriteLine("fun");
        }
        public void InvokeFromString(string functionName)
        {
            TestDelegate tDel = () => { this.GetType().GetMethod(functionName).Invoke(this, null); };
            tDel.Invoke();
        }
    }
