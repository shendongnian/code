    public class Program
    {
        public static void Main(string[] args)
        {
            string hello = "Endpoint: Efficacy, Intervene: Single Group, Mask: Open, Purpose: Treatment";
            string[] arr = hello.Split(',');
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach(string s in arr)
            {
                string[] keyValuePair = s.Split(':');
                result[keyValuePair[0].Replace(" ","")] = keyValuePair[1].Replace(" ","");
                
            }
            
            foreach(var v in result)
            {
                Console.WriteLine(v.Key + " : " + v.Value );
            }
            
            
        }
    }
