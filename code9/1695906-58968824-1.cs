C#
// This works for Microsoft.Extensions.Logging.Abstractions version 2.2.0
[Test]
public void Test_NSubstitute_ILogger_2_2_0()
{
	// Given
	var logger = Substitute.For<ILogger>();
	// When
	logger.LogError("Error message");
	logger.LogInformation("Information message");
	// Then
	logger.Received(1)
		.Log(LogLevel.Error, 0, Arg.Is<object>(x=> x.ToString().Equals("Error message")), null, Arg.Any<Func<object, Exception, string>>());
	logger.Received(1)
		.Log(LogLevel.Information, 0, Arg.Is<object>(x => x.ToString().Equals("Information message")), null, Arg.Any<Func<object, Exception, string>>());
}
C#
// This works for Microsoft.Extensions.Logging.Abstractions version 3.0.1
[Test]
public void Test_NSubstitute_ILogger_3_0_1()
{
	// Given
	var logger = Substitute.For<ILogger>();
	// When
	logger.LogError("Error message");
	logger.LogInformation("Information message");
	// Then
	logger.Received(1)
		.LogError("Error message");
	logger.Received(1)
		.LogError("Information message");
}
