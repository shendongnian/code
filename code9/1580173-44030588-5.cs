    using System;
    using System.IO;
    
    namespace Base64Decode
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] imagedata = Convert.FromBase64String(File.ReadAllText("example.b64"));
                File.WriteAllBytes("output.png",imagedata);
            }
        }
    }
