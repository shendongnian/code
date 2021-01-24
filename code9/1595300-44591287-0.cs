	using System;
	using NUnit.Framework;
	namespace TestsProject.StepDefinitions
	{
		[SetUpFixture]
		public class NUnitSetupFixture
		{
			[OneTimeSetUp]
			public void RunBeforeAnyTests()
			{
				//throw new Exception("This is called.");
			}
			[OneTimeTearDown]
			public void RunAfterAnyTests()
			{
			}
		}
	}
