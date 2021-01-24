    using System;
    using System.Runtime.InteropServices;
    using Word = Microsoft.Office.Interop.Word;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                object wordAsObject;
                Word.Application word;
    
                try
                {
                    wordAsObject = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                    //If there is a running Word instance, it gets saved into the word variable
                    word = (Word.Application)wordAsObject;
    
                    Console.WriteLine("{0}", word.ActiveDocument.FullName);
    
                    Console.ReadKey();
                }
                catch (COMException)
                {
                    //If there is no running instance, it creates a new one
                    //Type type = Type.GetTypeFromProgID("Word.Application");
                    //wordAsObject = System.Activator.CreateInstance(type);
                }
            }
        }
    }
