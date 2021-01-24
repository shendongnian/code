    using System;
    namespace WindowsFormsApp1
    {
      static class Program
      {
        [STAThread]
        static void Main()
        {
          string s = "{ \"A\": \"val-A\" }";
          Console.WriteLine(s);
          s = s.Substring(0, s.Length - 1) + ", \"your-prop-name\": \"the-prop-value\" }";
          Console.WriteLine(s);
        }
      }
    }
