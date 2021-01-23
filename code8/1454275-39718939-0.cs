    using System;
    
        namespace ImageDPI
        {
            public class Program
            {
                public static void Main(string[] args)
                {
                    int Aw, Ah, Rw, Rh, Adpi, Rdpi;
                    
                    Aw = 1200;
                    Ah = 788;
                    
                    Adpi = 300;
                    Rdpi = 72;
                    
                    Rw= (Aw * Rdpi) / Adpi;
                    Rh= (Ah * Rdpi) / Adpi;
                    
                    Console.WriteLine(Rw);
                    Console.WriteLine(Rh);
                    
                    
                }
            }
        }
