	class Evaluator {
		Dictionary<string, Func<dynamic, dynamic, dynamic>> BinaryOperatorsDyn = new Dictionary<string, Func<dynamic, dynamic, dynamic>>();
		public Evaluator() {
			LoadOperators();
		}
		void LoadOperators() {
			BinaryOperatorsDyn.Add("+", (x, y) => x + y);
			BinaryOperatorsDyn.Add("-", (x, y) => x - y);
			BinaryOperatorsDyn.Add("*", (x, y) => x * y);
		}
		public void DoDemo() {
			long x = 20;
			double y = 30;
			var oper = "+";
			var result = BinaryOperatorsDyn[oper](x, y);
			Console.WriteLine($"Result of {x} + {y} is {result}. Type of result is {result.GetType().ToString()}");
		}
	}
	class Program {
		static void Main(string[] args) {
			var eval = new Evaluator();
			eval.DoDemo();
		}
	}
