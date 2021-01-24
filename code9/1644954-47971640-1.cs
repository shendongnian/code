    using System;
    using System.Threading;
    using Microsoft.Build.BuildEngine;
    public static void Main()
	{
		string proj= @"yourprogram.csproj";
		string target = "Build";
		
		MyBuild mybuild = new MyBuild(proj, target);
		
		Thread t = new Thread(new ThreadStart(mybuild.Start));
		t.SetApartmentState(ApartmentState.STA);
		t.Start();
		t.Join();
		
		if (mybuild.Result) 
		{
			Console.WriteLine("Success!");
		}
		else
		{
			Console.WriteLine("Failed!");
		}
	}
