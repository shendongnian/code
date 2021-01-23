    public class Test {
        public static IFooController iFooController => (IFooController) new object();
        public static FooRequest CreateRequest<T>(Expression<Func<FooResponse<T>>> func) {
            return FooRequest.Create(func);
        }
        public static void Main() {
            var newRequest = CreateRequest(() => iFooController.GetEmployeeById("myPartner", 42, DateTime.Now.AddDays(-1)));
            Console.ReadKey();
        }
    }
    public class FooRequest {
        public static FooRequest Create<T>(Expression<Func<FooResponse<T>>> func) {
            var call = (MethodCallExpression) func.Body;
            var arguments = new List<object>();
            foreach (var arg in call.Arguments) {
                var constant = arg as ConstantExpression;
                if (constant != null) {
                    arguments.Add(constant.Value);
                }
                else {
                    var evaled = Expression.Lambda(arg).Compile().DynamicInvoke();
                    arguments.Add(evaled);
                }
            }
            return new FooRequest(call.Method.Name, arguments.ToArray());
        }
        public FooRequest(string function, object[] data = null) {
            //SendRequestToServiceBus(function, data);
            Console.Write($"Function name: {function}");
        }
    }
    public class FooResponse<T> {
    }
    public interface IFooController {
        FooResponse<string> GetEmployeeById(string partnerName, int employeeId, DateTime? ifModifiedSince);
    }
