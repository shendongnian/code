          void Main()
          {
		int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		Random rnd = new Random();
		System.Timers.Timer t = new System.Timers.Timer(1000);
		t.Elapsed += (s,e)=>{
			Console.WriteLine(rnd.Next(1, numbers.Length));
		};
		t.Start();
		Console.ReadLine();
         }
