	string[] lines = File.ReadAllLines("C:\\checker/in.txt");
	var accCount = lines.Count();
	Console.Write("Accounts loaded: " + accCount);
	Console.WriteLine();
	var checker = new Checker();
	
	var tasks =
		from line in lines
		let account = line.Split(new char[] { ':' })
		let user = account[0]
		let pass = account[0]
		select Task.Factory.StartNew(() =>  checker.checkAccount(user, pass));
	Task.WaitAll(tasks.ToArray());
	Console.ReadLine();
