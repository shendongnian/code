	public class Response<T>
	{
		public T Data { get; set; }
	
		public Response()
		{
			Data = default(T);
		}
	}
	
	public interface IOInterface<T> where T : Response<T>
	{
		T ReadAdvantechChannel(Dictionary<string, string> IOParameters);
	}
	
	public class AdvantechOperation : IOInterface<AIRecordInfo>
	{
		public AIRecordInfo ReadAdvantechChannel(Dictionary<string, string> IOParameters)
		{
			return new AIRecordInfo();
		}
	}
	
	public class AIRecordInfo : Response<AIRecordInfo>
	{
		double[] ArryMaxValueAIdouble;
		double[] ArryMinValueAIdouble;
		double[] ArryAVGValueAIdouble;
	}
