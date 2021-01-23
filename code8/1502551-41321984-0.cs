    namespace Rextester
    {
    	public class Program
    	{
    		public static void Main(string[] args)
    		{
    			var json = "[{\"period\":\"2013-3\",\"key\":1,\"val\":18148},{\"period\":\"2013-3\",\"key\":\"totalinteractions\",\"val\":95862},{\"period\":\"2013-3\",\"key\":\"totalusers\",\"val\":160389},{\"period\":\"2013-4\",\"key\":\">10\",\"val\":69915}]";
    			var inputdata = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(json);
    			var list = inputdata.Where(w => (string)w.key == "totalusers").Select(s => s.val).ToArray();
    			foreach (var item in list)
    			{
    				Console.WriteLine(item);
    			}
    		}
    	}
    }
