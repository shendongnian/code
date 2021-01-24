        static void Main(string[] args)
        {
            string DSN = "TEST";
            string[] subKeyNames = null;
            using (Microsoft.Win32.RegistryKey localMachineHive = Registry.LocalMachine)
            using (RegistryKey odbcDriversKey = localMachineHive.OpenSubKey(string.Format(@"SOFTWARE\ODBC\odbc.ini\{0}", DSN)))
            {
                subKeyNames = odbcDriversKey.GetValueNames();
                foreach (var subKey in subKeyNames)
                {
                    Console.WriteLine(subKey.ToString());
                }
                            
            }
            Console.Read();
        }
    
    //Result will be 
    
    //Driver
    //Server
    //LastUser
    //...
    //..
    //.
