    using System;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var parameters = GetParameters(args);
    
                var inputContent = GetInputContent(parameters);
    
                CreateOutputFile(parameters, inputContent);
    
                Console.WriteLine("it's ok. Press key to exit");
                Console.ReadKey();
            }
    
            private static void CreateOutputFile(MyProgramParameters parameters, string inputContent)
            {
                File.WriteAllText(parameters.OutputFileName, inputContent);
            }
    
            private static string GetInputContent(MyProgramParameters parameters)
            {
                var result = File.ReadAllText(parameters.InputFileName);
    
                return result;
            }
    
            private static MyProgramParameters GetParameters(string[] args)
            {
                CheckInputParameters(args);
    
                return new MyProgramParameters
                {
                    InputFileName = args[0],
                    OutputFileName = args[1]
                };
            }
    
            private static void CheckInputParameters(string[] args)
            {
                if (args.Length != 2)
                    throw new ArgumentException("invalid parameters. For example, myProgram.exe input1.txt   output.txt");
    
                var inputFileName = args[0];
    
                if (!File.Exists(inputFileName))
                    throw new IOException(string.Format("File {0} not found", inputFileName));
            }
        }
        
        public class MyProgramParameters
        {
            public string InputFileName { get; set; }
    
            public string OutputFileName { get; set; }
        }
    }
