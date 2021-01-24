	/// <summary>
	/// Verifies that a Log call has been made, with the given LogLevel, Message and optional KeyValuePairs.
	/// </summary>
	/// <typeparam name="T">Type of the class for the logger.</typeparam>
	/// <param name="loggerMock">The mocked logger class.</param>
	/// <param name="expectedLogLevel">The LogLevel to verify.</param>
	/// <param name="expectedMessage">The Message to verify.</param>
	/// <param name="expectedValues">Zero or more KeyValuePairs to verify.</param>
	public static void VerifyLog<T>(this Mock<ILogger<T>> loggerMock, LogLevel expectedLogLevel, string expectedMessage, params KeyValuePair<string, object>[] expectedValues)
	{
		loggerMock.Verify(mock => mock.Log(
			expectedLogLevel,
			It.IsAny<EventId>(),
			It.Is<It.IsAnyType>((o, t) => MatchesLogValues(o, expectedMessage, expectedValues)),
			It.IsAny<Exception>(),
			It.IsAny<Func<object, Exception, string>>()
			)
		);
	}
	/// <summary>
	/// Verifies that a Log call has been made, with LogLevel.Error, Message, given Exception and optional KeyValuePairs.
	/// </summary>
	/// <typeparam name="T">Type of the class for the logger.</typeparam>
	/// <param name="loggerMock">The mocked logger class.</param>
	/// <param name="expectedMessage">The Message to verify.</param>
	/// <param name="expectedException">The Exception to verify.</param>
	/// <param name="expectedValues">Zero or more KeyValuePairs to verify.</param>
	public static void VerifyLog<T>(this Mock<ILogger<T>> loggerMock, string expectedMessage, Exception expectedException, params KeyValuePair<string, object>[] expectedValues)
	{
		loggerMock.Verify(logger => logger.Log(
			LogLevel.Error,
			It.IsAny<EventId>(),
			It.Is<It.IsAnyType>((o, t) => MatchesLogValues(o, expectedMessage, expectedValues)),
			It.Is<Exception>(e => e == expectedException),
			It.Is<Func<It.IsAnyType, Exception, string>>((o, t) => true)
		));
	}
	private static bool MatchesLogValues(object state, string expectedMessage, params KeyValuePair<string, object>[] expectedValues)
	{
		const string messageKeyName = "{OriginalFormat}";
		var loggedValues = (IReadOnlyList<KeyValuePair<string, object>>)state;
		return loggedValues.Any(loggedValue => loggedValue.Key == messageKeyName && loggedValue.Value.ToString() == expectedMessage) &&
			   expectedValues.All(expectedValue => loggedValues.Any(loggedValue => loggedValue.Key == expectedValue.Key && loggedValue.Value == expectedValue.Value));
	}
