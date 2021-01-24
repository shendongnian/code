	public class Params
	{
		public string input;
	}
	Params globals = new Params();
	globals.input = "some lowercase text";
	string script = "string TryUpper(string str) { return str.ToUpper(); } return TryUpper(input);";
	string result = await CSharpScript.EvaluateAsync<string>(script, globals: globals);
