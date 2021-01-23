    class A {
        void Test() {
            IList<object> data = new List<object>();
            // can't pass in MyFunc, doesn't compile
            ApplyFunc(arg => MyFunc(arg), data);
        }
        int MyFunc(IList<object> data) {
            return 0;
        }
        void ApplyFunc<TEnumerable>(Func<TEnumerable, int> f, TEnumerable data)
		     where TEnumerable : IEnumerable<object>
	    {
           f(data);
        }
    }
