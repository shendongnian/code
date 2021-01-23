    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    //https://github.com/nunit/docs/wiki/SetUpFixture-Attribute
    //A SetUpFixture outside of any namespace provides SetUp and TearDown for the entire assembly.
    [SetUpFixture]
    class GlobalSetup
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int SetDllDirectory(string NewDirectory);
        static HashSet<string> directories = new HashSet<string>
        {
            @"D:\Drive\AnyThirdParty\"
        };
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            AddManagedHandler();
            SetNativeDirectories();
        }
        private void SetNativeDirectories()
        {
            if(directories.Count() != 1)
            {
                //TODO: add support for multiple directories
                throw new NotImplementedException("current implementation only supports exactly one directory");
            }
            if (0 == SetDllDirectory(directories.First()))
            {
                throw new Exception("SetDllDirectory failed with error " + Marshal.GetLastWin32Error());
            }
        }
        private void AddManagedHandler()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            IEnumerable<string> candidates = FindCandidates(new AssemblyName(args.Name));
            return Assembly.LoadFrom(candidates.First());
        }
        private static IEnumerable<string> FindCandidates(AssemblyName assemblyname)
        {
            List<string> candidates = new List<string>();
            foreach (var path in directories)
            {
                string candidate = string.Format(@"{0}{1}.dll", path, assemblyname.Name);
                if (File.Exists(candidate))
                {
                    candidates.Add(candidate);
                }
            }
            if (!candidates.Any())
            {
                throw new FileNotFoundException(string.Format("Can not find assembly: '{0}.dll'", assemblyname.Name));
            }
            return candidates;
        }
    }
