    public class Program
    	{
    		public static void Main(string[] args)
    		{
    			var fileParser = new FileParser(@"C:\textwords.csv");
    			if(fileParser.IsWordAvailable("abc"))
    			{
    				MessageBox.Show("Match found");
    			}
    			else
    			{
    				MessageBox.Show("No Match");
    			}
    		}
        }
