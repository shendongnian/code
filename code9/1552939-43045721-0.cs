    public class Parameter
    {
        protected dynamic value;
        public dynamic Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public Parameter(dynamic startingValue)
        {
            value = startingValue;
        }
    }
    public class MyStuff {
        public void DoStuff()
        {
            List<Parameter> storedParameters = new List<Parameter>();
            storedParameters.Add(new Parameter(2f));
            storedParameters.Add(new Parameter(7));
            foreach (Parameter p in storedParameters)
            {
                DoSomethingWithValue(p.Value);
            }
        }
    }
