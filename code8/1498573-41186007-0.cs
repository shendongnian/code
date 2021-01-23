    delegate T MeDelegate<T>();
	class Program
	{
		static void Main(string[] args)
		{
			Func<object> functionDelegates = ReturnFive;
			functionDelegates += ReturnTen;
			functionDelegates += ReturnTwentyTwo;
			functionDelegates += ReturnSomeDoubleValue;
			foreach (object value in GetAllReturnValues(functionDelegates))
			{
				Console.WriteLine(value);
			}
			Console.ReadKey();
		}
		static IEnumerable<TArgs> GetAllReturnValues<TArgs>(Func<TArgs> functionDelegates)
		{
			return from Func<TArgs> function in functionDelegates.GetInvocationList() select function();
		}
		static object ReturnFive() { return 5; }
		static object ReturnTen() { return 10; }
		static object ReturnTwentyTwo() { return 22; }
		static object ReturnSomeDoubleValue() { return 1.0; }
	}
