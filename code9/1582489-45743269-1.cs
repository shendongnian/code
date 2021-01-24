    static void Main(string[] args)
    {
        string DSN = "TEST";
        using (Microsoft.Win32.RegistryKey localMachineHive = Registry.LocalMachine)
        using (RegistryKey odbcDriversKey = localMachineHive.OpenSubKey(string.Format(@"SOFTWARE\ODBC\odbc.ini\{0}", DSN)))
        {
            if (odbcDriversKey != null)
            {
                Console.Write(odbcDriversKey.GetValue("Server").ToString());
            }
        }
        Console.Read();
    }
