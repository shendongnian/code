	static void Main() {
		Func<string, int> method = Worker;
		var arg1 = "Hello world!";
		var output = method.BeginInvoke(arg1, Done, Tuple.Create(method, arg1));
		Console.ReadLine();
	}
	static void Done(IAsyncResult cookie) {
		var target = (Tuple<Func<string, int>, string>)cookie.AsyncState;
		int result = target.Item1.EndInvoke(cookie);
		Console.WriteLine("String length is " + result);
		Console.WriteLine("Passed argument was " + target.Item2);
	}
	static int Worker(string s) {
		return s.Length;
	}
