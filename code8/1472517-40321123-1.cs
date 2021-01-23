    internal class Program
	{
		private static void Main(string[] args)
		{
			var assembly = Assembly.LoadFrom("System.Speech.dll");
			var type = assembly.GetType("System.Speech.Synthesis.SpeechSynthesizer");
			var methodinfo = type.GetMethod("SpeakAsync", new[] {typeof(string)});
			if (methodinfo == null) throw new Exception("No methodinfo.");
			var speechparameters = new object[1];
			speechparameters[0] = "+100"; // returns something like "+100"
			var o = Activator.CreateInstance(type);
			var prompt = (Prompt) methodinfo.Invoke(o, speechparameters);
			while (!prompt.IsCompleted)
			{
				Task.Delay(500).Wait();
			}
		}
	}
