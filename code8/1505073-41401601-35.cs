    using Newtonsoft.Json;
	public static class ConverterHelpers
	{
		public static string SerializeObject(object value)
		{
			return JsonConvert.SerializeObject(value);
		}
		public static T DeserializeObject<T>(string value)
		{
			return JsonConvert.DeserializeObject<T>(value);
		}
	}
