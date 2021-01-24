        public class MyClientMessageInspector : IClientMessageInspector
    {
        public MyClientMessageInspector(ServiceEndpoint endpoint)
        {
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            //Console.WriteLine(request.ToString());
	        var lstUnwantedStuff = new[]
	        {
		        new KeyValuePair<string, string>("Action", "http://www.w3.org/2005/08/addressing"),
		        new KeyValuePair<string, string>("VsDebuggerCausalityData",
			        "http://schemas.microsoft.com/vstudio/diagnostics/servicemodelsink")
	        };
			
			foreach (var kv in lstUnwantedStuff)
			{
				var indexOfUnwantedHeader = request.Headers.FindHeader(kv.Key, kv.Value);
				if (indexOfUnwantedHeader>=0)
				{
					request.Headers.RemoveAt(indexOfUnwantedHeader);
				}
			}
