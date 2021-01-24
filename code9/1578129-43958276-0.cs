    public class Program
    {
        public static void Main(string[] args)
        {
            for (int a = 0; a < 256; a++)
            {
			   for (int b = 0; b < 256; b++)
			   {
				   for (int c = 0; c < 256; c++) 
				   {
					   for (int d = 0; d < 256; d++)
					   {
						   string ipAddress = string.Format("{0}.{1}.{2}.{3}", a, b, c, d);
						   Console.WriteLine(ipAddress);
					   }
				   }
			   }
            }
        }
    }
