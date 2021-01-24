    class ResultClass
    {
    }
    class OtherClass
    {
    }
    class MethodHolder
    {
        private readonly Dictionary<string, Func<object[], object>> Dict;
        public MethodHolder()
        {
            Dict = new Dictionary<string, Func<object[], object>>();
            Dict.Add("MethodA", (x) => MethodA(x));
            Dict.Add("MethodB", (x) => MethodB(x));
            Dict.Add("MethodC", (x) => MethodC(x));
        }
        public object MethodA(object[] param)
        {
            //some code
            return new ResultClass();
        }
        public object MethodB(object[] param)
        {
            //this is your void example
            return null;
        }
        public object MethodC(object[] param)
        {
            //some more code
            return new OtherClass();
        }
        public void HowToUse()
        {
            var method = Dict["MethodA"];
            method.Invoke(new object[] { });
        }
    }
