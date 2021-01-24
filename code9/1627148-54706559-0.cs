cs
public class ControllerNotImplementedTelemetryProcessor : ITelemetryProcessor
{
	private ITelemetryProcessor Next { get; }
	public void Process(ITelemetry item)
	{
		var exception = item as ExceptionTelemetry;
		if (exception != null && exception.Exception.GetType() == typeof(HttpException) && exception.Exception.Message.Contains("was not found or does not implement IController"))
			return;
		Next.Process(item);
	}
	public ControllerNotImplementedTelemetryProcessor(ITelemetryProcessor next)
	{
		Next = next;
	}
}
Registering the custom processor happens in Global.ascx:
cs
TelemetryConfiguration.Active.TelemetryProcessorChainBuilder
    .Use(next => new ControllerNotImplementedTelemetryProcessor(next))
    .Build();
Note that this is obviously  a very crude filter, depending on the language of the error message to be English might be acceptable but could also cause false positives.
