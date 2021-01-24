    using System;
    using System.Text.RegularExpressions;
    using System.IO;
    
    namespace Example.Lib.Common
    {
        /// <summary>
        /// Reads /proc/cpuinfo to obtain common values
        /// </summary>
        public class LinuxCpuInfo
        {
            public string VendorId { get; private set; }
            public int CpuFamily { get; private set; }
            public int Model { get; private set; }
            public string ModelName { get; private set; }
            public int Stepping { get; private set; }
            public double MHz { get; private set; }
            public string CacheSize { get; private set; }
    
            public void GetValues()
            {
                string[] cpuInfoLines = File.ReadAllLines(@"/proc/cpuinfo");
    
                CpuInfoMatch[] cpuInfoMatches =
                {
                    new CpuInfoMatch(@"^vendor_id\s+:\s+(.+)", value => VendorId = Conversion.ObjectToString(value)),
                    new CpuInfoMatch(@"^cpu family\s+:\s+(.+)", value => CpuFamily = Conversion.ObjectToInt(value)),
                    new CpuInfoMatch(@"^model\s+:\s+(.+)", value => Model = Conversion.ObjectToInt(value)),
                    new CpuInfoMatch(@"^model name\s+:\s+(.+)", value => ModelName = Conversion.ObjectToString(value)),
                    new CpuInfoMatch(@"^stepping\s+:\s+(.+)", value => Stepping = Conversion.ObjectToInt(value)),
                    new CpuInfoMatch(@"^cpu MHz\s+:\s+(.+)", value => MHz = Conversion.ObjectToDouble(value)),
                    new CpuInfoMatch(@"^cache size\s+:\s+(.+)", value => CacheSize = Conversion.ObjectToString(value))
                };
    
                foreach (string cpuInfoLine in cpuInfoLines)
                {
                    foreach (CpuInfoMatch cpuInfoMatch in cpuInfoMatches)
                    {
                        Match match = cpuInfoMatch.regex.Match(cpuInfoLine);
                        if (match.Groups[0].Success)
                        {
                            string value = match.Groups[1].Value;
                            cpuInfoMatch.updateValue(value);
                        }
                    }
                }
            }
    
            public class CpuInfoMatch
            {
                public Regex regex;
                public Action<string> updateValue;
    
                public CpuInfoMatch(string pattern, Action<string> update)
                {
                    this.regex = new Regex(pattern, RegexOptions.Compiled);
                    this.updateValue = update;
                }
            }
        }
    }
