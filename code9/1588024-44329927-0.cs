    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    namespace libsvm2tsv
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sw = Stopwatch.StartNew();
                switch (args[0])
                {
                    case "-t": LoadAll(args[1], LoadFile); break;
                    case "-p": LoadAll(args[1], RunChild); break;
                    case "-f": LoadFile(args[1]); return;
                }
                Console.WriteLine("ELAPSED: {0} sec.", sw.ElapsedMilliseconds / 1000);
                Console.ReadLine();
            }
            static void LoadAll(string folder, Action<string> algorithm)
            {
                Parallel.ForEach(
                    Directory.EnumerateFiles(folder),
                    new ParallelOptions { MaxDegreeOfParallelism = 12 },
                    f => algorithm(f));
            }
            static void RunChild(string file)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = Assembly.GetEntryAssembly().Location,
                    Arguments = "-f \"" + file + "\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                })
                .WaitForExit();
            }
            static void LoadFile(string inFile)
            {
                using (var ins = File.OpenText(inFile))
                    while (ins.Peek() >= 0)
                        ParseLine(ins.ReadLine());
            }
            static long[] ParseLine(string line)
            {
                // first, count number of items
                var items = 1;
                for (var i = 0; i < line.Length; i++)
                    if (line[i] == ' ') items++;
                //allocate memory and parse items
                var all = new long[items];
                var n = 0;
                var index = 0;
                while (index < line.Length)
                {
                    var next = line.IndexOf(' ', index);
                    if (next < 0) next = line.Length;
                    if (next > index)
                    {
                        var v = (long)(parseDouble(line, line.IndexOf(':', index) + 1, next - 1) * 1000);
                        if (v < 0) v = -1;
                        all[n++] = v;
                    }
                    index = next + 1;
                }
                return all;
            }
            private readonly static double[] pow10Cache;
            static Program()
            {
                pow10Cache = new double[309];
                double p = 1.0;
                for (int i = 0; i < 309; i++)
                {
                    pow10Cache[i] = p;
                    p /= 10;
                }
            }
            static double parseDouble(string input, int from, int to)
            {
                long inputLength = to - from + 1;
                long digitValue = long.MaxValue;
                long output1 = 0;
                long output2 = 0;
                long sign = 1;
                double multiBy = 0.0;
                int k;
                //integer part
                for (k = 0; k < inputLength; ++k)
                {
                    digitValue = input[k + from] - 48; // '0'
                    if (digitValue >= 0 && digitValue <= 9)
                    {
                        output1 = digitValue + (output1 * 10);
                    }
                    else if (k == 0 && digitValue == -3 /* '-' */)
                    {
                        sign = -1;
                    }
                    else if (digitValue == -2 /* '.' */ || digitValue == -4 /* ',' */)
                    {
                        break;
                    }
                    else
                    {
                        return double.NaN;
                    }
                }
                //decimal part
                if (digitValue == -2 /* '.' */ || digitValue == -4 /* ',' */)
                {
                    multiBy = pow10Cache[inputLength - (++k)];
                    for (; k < inputLength; ++k)
                    {
                        digitValue = input[k + from] - 48; // '0'
                        if (digitValue >= 0 && digitValue <= 9)
                        {
                            output2 = digitValue + (output2 * 10);
                        }
                        else
                        {
                            return Double.NaN;
                        }
                    }
                    multiBy *= output2;
                }
                return sign * (output1 + multiBy);
            }
        }
    }
