	var t = Task.Run(() => throw new Exception(DateTime.Now.Ticks.ToString()));
	try {
		await t;
	} catch (Exception e) {
		Console.WriteLine(e.Message);
	}
	await Task.Delay(1000);
	try {
		await t;
	} catch (Exception e) {
		Console.WriteLine(e.Message);
	}
