    static void Main(string[] args)
    {
        IObservable<char> sequence = Observable.Create<char>(o =>
        {
			string message =  "hello world!";
			return
				Observable
					.Generate(
						0,
						n => n < message.Length,
						n => n + 1,
						n => message[n],
						n => TimeSpan.FromMilliseconds(250.0))
					.Subscribe(o);
        });
        using (sequence.Subscribe(p => Console.Write(p)))
		{
			Console.ReadLine();
		}
    }
