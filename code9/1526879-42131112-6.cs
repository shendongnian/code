    public class CleanOperationInvoker:IOperationInvoker
    {
        private readonly IOperationInvoker _invoker;
        public CacheOperationInvoker(IOperationInvoker invoker)
        {
            _invoker = invoker;
        }
        
        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            inputs = CleanInputs(inputs);
            return _invoker.Invoke(instance, inputs, out outputs);
        }
        private static object[] CleanInputs(object[] inputs)
        {
            for(int i = 0; i < inputs.Length;i++)
            {
                 var str = inputs[i] as string;
                 if(!string.IsNullOrEmpty(str))
                     inputs[i] = StripHTML(str);
            }
            return inputs;
        }
        public static string StripHTML(string input)
        {
           return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
