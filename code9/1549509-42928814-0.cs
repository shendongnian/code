    using System; 
    using System.Collections.Generic; 
    using System.Text; 
    
    namespace ConsoleApplication2 
    { 
        class Program 
        { 
            static void Main(string[] args) 
            { 
                // Create the MATLAB instance 
                MLApp.MLApp matlab = new MLApp.MLApp(); 
    
                // Change to the directory where the function is located 
                matlab.Execute(@"cd c:\temp\example"); 
    
                // Define the output 
                object result = null; 
    
                // Call the MATLAB function myfunc
                matlab.Feval("myfunc", 2, out result, 3.14, 42.0, "world"); 
                 
                // Display result 
                object[] res = result as object[]; 
                 
                Console.WriteLine(res[0]); 
                Console.WriteLine(res[1]); 
                Console.ReadLine(); 
            } 
        } 
    } 
