    class Program
	{
		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			var w = new Work();
			Console.WriteLine("Main Thread Start");
			ThreadStart s = w.Count;
			var thread1 = new Thread(s);
			thread1.Start();
			int i = 2;
			Console.SetCursorPosition(0, i);
			var format = "Input:";
			Console.WriteLine(format);
			Console.SetCursorPosition(format.Length + 1, i);
			string input = Console.ReadLine();
			Console.WriteLine(input);
		}
	}
    public class Work
	{
		public void Count()
		{
			while (true)
			{
				Thread.Sleep(1000);
				var originalX = Console.CursorLeft;
				var originalY = Console.CursorTop;
				Console.SetCursorPosition(0, 1);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition((Console.WindowWidth - 8) / 2, 0);
				Console.Write("{0:HH:mm:ss}", DateTime.Now);
				Console.SetCursorPosition(originalX, originalY);
			}
		}
	}
