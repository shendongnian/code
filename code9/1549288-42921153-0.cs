       var XMLpath = "c:\test.xml"; //<< your xml here
        if (!File.Exists(XMLpath))
        {
            using (StreamWriter XmlWrite = new StreamWriter(XMLpath, false))
            {
                string[] x = {@"<?xml version=""1.0""?>",
                               @"<configuration>",
                               @"<connectionStrings>",
                               @"<add name=""abcConnection"" connectionString=""server=10.10.12.12;database=Test1;uid=myUI‌​D;password=hello;tim‌​eout=20;""providerNam‌​e=""System.Data.SqlCl‌​ient"" />""",
                               @"<add name=""123Connection"" connectionString=""server=10.10.23.45;database=test2;uid=MyUS‌​I;password=hello;"" providerName=""System.Data.SqlClient"" />",
                               @"</connectionStrings>",
                               @"</configuration>}";
                foreach (string s in x)
                {
                    XmlWrite.WriteLine(s);
                }
            }
        }
