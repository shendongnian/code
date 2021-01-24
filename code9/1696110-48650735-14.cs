    public class Program
    {
        static void Main(string[] args)
        {
            var wcfClient = new MyService.ServiceClient();
            try
            {
                var result = wcfClient.Divide(10, 5);
                Console.WriteLine(result);
            }
            catch (FaultException<SecurityFault> securityFault)
            {
                Console.WriteLine(securityFault.Detail.Operation);
                Console.WriteLine(securityFault.Detail.ProblemType);
            }
            Console.ReadLine();
        }
    }
