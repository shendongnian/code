	string systemVar = System.Environment.GetEnvironmentVariable("JAVA_HOME");
	CodeActivity4.Report("systemVar", systemVar);
	
	string userVar = this.CodeActivity4.Input.myVar;
	CodeActivity4.Report("userVar", userVar);
	
	string testVar = this.Context.TestProfile.GetVariableValue("TestName");
	CodeActivity4.Report("testVar", testVar);
