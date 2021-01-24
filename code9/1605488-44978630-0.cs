    using System.IO;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main (string[] args)
            {
                var text = "line 1\r\nline 2\r\nline 3\r\nline 4";
                using (var sr = new StringReader (text))
                {
                    sr.ReadLine ();
                    sr.ReadLine ();
                    string result = sr.ReadToEnd ();
                }
            }
        }
    }
