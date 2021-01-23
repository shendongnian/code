    using System;
    using System.Collections.Generic;
    using System.Text;
    using cwbx;
     
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string result = string.Empty;
     
                StringConverter stringConverter = new StringConverterClass();
     
                // Define an AS400 system and connect to it
                AS400System system = new AS400System();
                system.Define("AS400");
                system.UserID = "USERNAME";
                system.Password = "PASSWORD";
                system.IPAddress = "127.0.0.1";
                system.Connect(cwbcoServiceEnum.cwbcoServiceRemoteCmd);
     
                // Check the connection
                if (system.IsConnected(cwbcoServiceEnum.cwbcoServiceRemoteCmd) == 1)
                {
                    // Create a program object and link to a system                
                    cwbx.Program program = new cwbx.Program();
                    program.LibraryName = "LIBRARY";
                    program.ProgramName = "RPGPROG";
                    program.system = system;
     
                    // Sample parameter data
                    char chrValue = '1';
    				string strValue1 = "ABC";
    				string strValue2 = "DEF";
    				string outp = "";
     
                    // Create a collection of parameters associated with the program
                    ProgramParameters parameters = new ProgramParameters();
                    
    				parameters.Append("P1", cwbrcParameterTypeEnum.cwbrcInput, 1);
    				parameters["P1"].Value = chrValue;
    				
    				parameters.Append("P2"), cwbrcParameterTypeEnum.cwbrcInput, 3);
    				parameters["P2"].Value = strValue1;
    				
    				parameters.Append("P3"), cwbrcParameterTypeEnum.cwbrcInput, 3);
    				parameters["P3"].Value = strValue1;
    				
                    parameters.Append("P4", cwbrcParameterTypeEnum.cwbrcOutput, 3);
                    
     
                    outp = stringConverter.FromBytes(parameters["P4"].Value);
                }
     
                system.Disconnect(cwbcoServiceEnum.cwbcoServiceAll);
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }
    }
