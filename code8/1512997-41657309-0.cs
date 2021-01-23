    using System;
    namespace RedirectConsoleSample
    {
        class Program
        {
    #if DEBUG
            static Program()
            {
                System.IO.TextReader oldConsoleTextReader = Console.In;
                System.IO.TextWriter oldConsoleTextWriter = Console.Out;
                System.IO.TextReader newConsoleTextReader = null;
                System.IO.TextWriter newConsoleTextWriter = null;
                AppDomain.CurrentDomain.ProcessExit += delegate (object sender, EventArgs e)
                {
                    try
                    {
                        Console.Out.Flush();
                        Console.SetOut(oldConsoleTextWriter);
                        Console.SetIn(oldConsoleTextReader);
                        if (newConsoleTextWriter != null)
                        {
                            newConsoleTextWriter.Close();
                            newConsoleTextWriter = null;
                        }
                        if (newConsoleTextReader != null)
                        {
                            newConsoleTextReader.Close();
                            newConsoleTextReader = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.TraceError("ProcessExit: " + ex.Message);
                    }
                };
                newConsoleTextReader = new System.IO.StreamReader("Input.txt", System.Text.Encoding.Default, true);
                newConsoleTextWriter = new System.IO.StreamWriter("Output.txt", false, System.Text.Encoding.Default);
                Console.Out.Flush();
                Console.SetIn(newConsoleTextReader);
                Console.SetOut(newConsoleTextWriter);
            }
    #endif
            static void Main(string[] args)
            {
                for (int i = 0; i < args.Length; i++)
                    Console.Out.WriteLine("argument[{0}] = '{1}'", i, args[i]);
                for (string line = Console.In.ReadLine(); line != null; line = Console.In.ReadLine())
                    Console.Out.WriteLine(line);
            }
        }
    }
