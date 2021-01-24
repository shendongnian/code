    using Microsoft.SqlServer.Dac;
    
    class Program
    {
        static void Main(string[] args)
        {
            DacServices ds = new DacServices(@"Data Source=SERVERNAME;Initial Catalog=DATABASENAME;Integrated Security=true");
            using (DacPackage dp = DacPackage.Load(@"C:\temp\mydb.dacpac"))
            {
                ds.Deploy(dp, @"DATABASENAME", upgradeExisting: false, options: null, cancellationToken: null);
            }
        }
    }
