	public interface IServiceWCF
	{
		[OperationContract]
		DateTime TestConnectionSpeed(DateTime messageSentFromClientTime, out DateTime messageReceivedAtServerTime, out int millisecondsBetweenClientSentAndServerReceived);
	}
	public class ServiceWCF : IServiceWCF
	{
		public DateTime TestConnectionSpeed(DateTime messageSentFromClientTime, out DateTime messageReceivedAtServerTime, out int millisecondsBetweenClientSentAndServerReceived)
		{
			messageReceivedAtServerTime = DateTime.Now;
			TimeSpan span = messageReceivedAtServerTime - messageSentFromClientTime;
			millisecondsBetweenClientSentAndServerReceived = (int)span.TotalMilliseconds;
			return DateTime.Now;
		}
	}	
