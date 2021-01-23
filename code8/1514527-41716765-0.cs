    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace FileAppending
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] doc1 =             File.ReadAllLines("C:\\FileAppending\\FileAppending\\Doc1.Docx");
            string[] doc2 =     File.ReadAllLines("C:\\FileAppending\\FileAppending\\Doc2.Docx");
           
                   File.WriteAllLines("C:\\FileAppending\\FileAppending\\Doc3.Docx", doc1);
                   File.AppendAllLines("C:\\FileAppending\\FileAppending\\Doc3.Docx", doc2);
             
           
            
            }
        }
    }
