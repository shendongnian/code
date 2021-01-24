    namespace Assigntment5_Console
    {
        class Program
        {
            [BearData.BearData("Bear", Weight = 1000)]
            static void Main(string[] args)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                object[] attrs = method.GetCustomAttributes(typeof(BearData.BearData), true);   
    
                BearData.BearData bearAttribute;
                bearAttribute = (BearData.BearData)attrs[0];   
    
                Console.WriteLine("Animal: " + bearAttribute.Bear + "\nAverage Weight: " + bearAttribute.Weight);
                Console.ReadLine();
            }
        }
    }
