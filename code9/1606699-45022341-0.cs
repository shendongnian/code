    class Program
    {
        static void Main(string[] args)
        {
            PrintKeyWords.CheckForKeyWord("print hello world!!!");
            PrintKeyWords.CheckForKeyWord("specialPrint hello world!!!");
            Console.ReadLine();
        }
    }
    
    delegate void ExecuteMethod();
    public static class PrintKeyWords
    {
    
        private static string Command { get; set; }
        public static void CheckForKeyWord(string cmd)
        {
    
            foreach (KeyValuePair<string, ExecuteMethod> keyword in KeyWordsDict)
            {
                if (cmd.StartsWith(keyword.Key))
                {
                    Command = cmd;
                    KeyWordsDict[keyword.Key].Invoke();
                    return;
                }
            }
                Console.WriteLine("your command is not recognized as an internal or exter
        }
    
        private static Dictionary<string, ExecuteMethod> _KeyWordsDict;
        private static Dictionary<string, ExecuteMethod> KeyWordsDict
        {
            get
            {
                if (_KeyWordsDict == null)
                {
                    _KeyWordsDict = new Dictionary<string, ExecuteMethod>();
                    _KeyWordsDict.Add("print", Print);
                    _KeyWordsDict.Add("specialPrint", SpecialPrint);
                    return _KeyWordsDict;
                }
    
                else
                {
                    return _KeyWordsDict;
                }
            }
        }
    
        private static void Print()
        {
            Console.WriteLine(Command.Replace("print", ""));
        }
    
        private static void SpecialPrint()
        {
            Console.WriteLine(Command.Replace("specialPrint", "") + "*****************");
        }
    } 
