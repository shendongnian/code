    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace Accounts
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                const string filename = "accounts.json";
                List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(System.IO.File.ReadAllText(filename));
    
                foreach (Account account in accounts)
                {
                    Console.WriteLine(account.AccountName);
                    foreach (File file in account.Files)
                    {
                        Console.WriteLine(file.Filename);
                    }
    
                    Console.WriteLine();
                }
            }
        }
    }
