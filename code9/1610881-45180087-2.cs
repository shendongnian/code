    using System;
    using System.IO;
    using Antlr4.Runtime;
    using Antlr4;
    using Antlr4.Runtime.Tree;
    
    namespace ANTLR_File_To_Arrray
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string SOURCEFILE = @"D:\prj\ANTLR_File_To_Arrray\ANTLR_File_To_Arrray\source1.txt";
                using (StreamReader fileStream = new StreamReader(SOURCEFILE))
                {
                    AntlrInputStream inputStream = new AntlrInputStream(fileStream);
                    ValuesLexer lexer = new ValuesLexer(inputStream);
                    CommonTokenStream tokenStream = new CommonTokenStream(lexer);
                    ValuesParser parser = new ValuesParser(tokenStream);
                    ValuesParser.ParseContext context = parser.parse();
                    ValuesListener listener = new ValuesListener();
                    ParseTreeWalker walker = new ParseTreeWalker();
                    bool built = parser.BuildParseTree;
                    walker.Walk(listener, context);
                    foreach (double d in listener.doubles)
                        Console.WriteLine(d);
                    Console.ReadKey();
                }
            }
        }
    }
