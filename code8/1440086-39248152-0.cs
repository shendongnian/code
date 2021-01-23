	var code = @"
	var a = 0;
	var b = 1 / a;
	";
	var script = CSharpScript.Create(code);
	var compilation = script.GetCompilation();
	var ilstream = new MemoryStream();
	var pdbstream = new MemoryStream();
	compilation.Emit(ilstream, pdbstream);
	var assembly = Assembly.Load(ilstream.GetBuffer(), pdbstream.GetBuffer());
	var type = assembly.GetType("Submission#0");
	var factory = type.GetMethod("<Factory>");
	var submissionArray = new object[2];
	Task<object> task = (Task<object>)factory.Invoke(null, new object[] { submissionArray });
	try
	{
		await task;
	}
	catch (DivideByZeroException dbze)
	{
		Console.WriteLine(dbze.StackTrace);
	}
