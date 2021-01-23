    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using NLog;
    using System.Collections;
    using System.Data;
    
    namespace DynamicEFLoading
    {
        class Utils
        {
            private static Logger logit = LogManager.GetCurrentClassLogger();
    
            public ArrayList HeadersFromDataTable(DataTable theDataTable)
            {
                ArrayList arHeaders = new ArrayList();
                try
                {
                    arHeaders.AddRange(theDataTable.Columns);
                    logit.Info("loaded {0} column headers...", arHeaders.Count);
                }
                catch (Exception ex)
                {
                    logit.Fatal("exception: " + ex.ToString());
                }
                return arHeaders;
            }
    
            public object CreateInstanceOf(string ClassName, string AssemblyFullPath)
            {
                var assemblyFullPath = Assembly.LoadFrom(@"C:\Users\<some user>\Documents\Visual Studio 2015\Projects\PoliticWebSite\ScratchConsole1\bin\Debug\ScratchConsole1.exe");
                var assembly = Assembly.GetExecutingAssembly();
                //var assembly = Assembly.LoadFrom(assemblyFullPath);
                var type = assembly.GetTypes().First(t => t.Name == ClassName);
                return Activator.CreateInstance(type);
            }
    
            public static string GenerateName(int len)
            {
                Random rndSeed = new Random(DateTime.Now.Millisecond);
                Random r = new Random(rndSeed.Next());
                string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
                string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
                string Name = "";
                Name += consonants[r.Next(consonants.Length)].ToUpper();
                Name += vowels[r.Next(vowels.Length)];
                int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
                while (b < len)
                {
                    //_________________________________________________________________
                    rndSeed = new Random(DateTime.Now.Millisecond);
                    r = new Random(rndSeed.Next());
                    Name += consonants[r.Next(consonants.Length)];
                    b++;
                    //_________________________________________________________________
                    rndSeed = new Random(DateTime.Now.Millisecond);
                    r = new Random(rndSeed.Next());
                    Name += vowels[r.Next(vowels.Length)];
                    b++;
                    //_________________________________________________________________
                }
                return Name;
            }
        }
    }
