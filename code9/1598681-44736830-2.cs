    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace ClientApp.Portable
    {
    	public class SendReceiveTest
    	{
    		public static async Task<string> Test(string data)
    		{
    			using (var client = new HttpClient())
    			{
    				var uri = $"http://192.168.0.103:53325/api/values?file={data}";
    				var response = await client.GetAsync(uri);
    				var stringData = await response.Content.ReadAsStringAsync();
    				return stringData;
    			}
    		}
    	}
    }
    
