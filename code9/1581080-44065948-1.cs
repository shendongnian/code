	using Microsoft.ServiceFabric.Services.Remoting.Client;
	using MyStatelessService.Interfaces;
	using System;
	static void Main(string[] args)
	{
		var calculatorClient = ServiceProxy.Create<ICalculatorService>
			(new Uri("fabric:/CalculatorService/MyStatelessService"));
		var result = calculatorClient.Add(1, 2).Result;
		Console.WriteLine(result);
		Console.ReadKey();
	}
