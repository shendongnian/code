    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.IO;
    
    namespace GetRDPSessionVariablesofCurrentConnectedUser
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                Console.WriteLine();
                Console.WriteLine("GetEnvironmentVariables: Machine");
               
                foreach (DictionaryEntry de in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine))
                {
                    string log = "\r\n" + de.Key + "=" + de.Value;
                    
                    Console.WriteLine(" {0} = {1}", de.Key, de.Value);
                }
                Console.WriteLine();
                Console.WriteLine("GetEnvironmentVariables: Process");
                foreach (DictionaryEntry de in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process))
                {
                    string log = "\r\n" + de.Key + "=" + de.Value;
                    
                    Console.WriteLine(" {0} = {1}", de.Key, de.Value);
                }
                Console.WriteLine();
                Console.WriteLine("GetEnvironmentVariables: User");
               
                foreach (DictionaryEntry de in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User))
                {
                    string log = "\r\n" + de.Key + "=" + de.Value;
                    
                    Console.WriteLine(" {0} = {1}", de.Key, de.Value);
                }
               
                Console.ReadLine();
            }
        }
    }
