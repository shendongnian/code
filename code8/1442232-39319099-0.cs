    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> datasource = new List<string>() { "A", "B", "C" };
                List<string> datafixed = new List<string>() { "D", "E", "F", "G", "H" };
                var results1 = datasource.Select((x,i) => new { source = x, fix = i < datafixed.Count ? datafixed[i] : null}).ToList();
                var results2 = datafixed.Select((x, i) => new { source = x, fix = i < datasource.Count ? datasource[i] : null }).ToList();
            }
        }
    }
