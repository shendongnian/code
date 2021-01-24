    //  T  -> TArg
    //  T2 -> TResult
    public abstract class MyBaseClass<TArg>
    {
        public class MyExpressionClass<TResult> : MyBaseClass<TArg>
        {
            public Expression<Func<TArg, TResult>> Expression { get; private set; }
            public MyExpressionClass(Expression<Func<TArg, TResult>> expression)
            {
                this.Expression=expression;
            }
        }
        public class MyCollectionClass 
        {
            public List<MyBaseClass<TArg>> MyGenericList = new List<MyBaseClass<TArg>>();
            public MyExpressionClass<TResult> ReceivingMethod<TResult>(Expression<Func<TArg, TResult>> expression)
            {
                var genericImp = new MyExpressionClass<TResult>(expression);
                MyGenericList.Add(genericImp);
                return genericImp;
            }
        }
        public class Client
        {
            public MyCollectionClass List = new MyCollectionClass();
            public void Do<TResult>()
            {
                foreach(var item in List.MyGenericList)
                {
                    var expr = item as MyExpressionClass<TResult>;
                    if(expr!=null)
                    {
                        var a = expr.Expression;
                        Console.WriteLine(a);
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MyBaseClass<int>.Client();
            // add conversion expressions
            client.List.ReceivingMethod((i) => (i).ToString());
            client.List.ReceivingMethod((i) => (2*i).ToString());
            client.List.ReceivingMethod((i) => (3*i).ToString());
            // The programmer has to manually enforce the `string` type
            // below based on the results of the expressions above. There
            // is no way to enforce consistency because `TResult` can be 
            // _any_ type. 
            client.Do<string>();
            // Produces the following output
            //
            // i => i.ToString()
            // i => (2*i).ToString()
            // i => (3*i).ToString()
        }
    }
