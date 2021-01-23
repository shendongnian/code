    using System;
    using AttributeWcfTest.ServiceRef;
    
    namespace AttributeWcfTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var client = new ServiceRef.ServiceClient();
                var testDto = new ServiceDto()
                {
                    DtoField = "Test Value"
                };
    
                var response = client.TestMethod(testDto);
                Console.WriteLine(response);
                Console.ReadLine();
            }
        }
    }
