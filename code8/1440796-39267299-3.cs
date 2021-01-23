    using System;
    using System.Text.RegularExpressions;
    
    namespace StackOwerflow
    {
        public class Program
        {
            static public void Main()
            {
                int repeats = 10000;
    
                string imgStr = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAB0IAAAQ4CAIAA...eXiM/H/wAAAABJRU5ErkJggg=="; //146 kb img file
                string r = string.Empty;
    
                var watch = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < repeats; i++)
                {
                    r = RegExMethod(imgStr);
                }
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
    
                Console.WriteLine("RegEx time: {0} Ms", elapsedMs);
    
                watch = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < repeats; i++)
                {
                    r = SubStringMethod(imgStr);
                }
                watch.Stop();
                elapsedMs = watch.ElapsedMilliseconds;
    
                Console.WriteLine("SubString time: {0} Ms", elapsedMs);
    
                watch = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < repeats; i++)
                {
                    r = SplitMethod(imgStr);
                }
                watch.Stop();
                elapsedMs = watch.ElapsedMilliseconds;
    
                Console.WriteLine("Split time: {0} Ms", elapsedMs);
    
                Console.ReadKey();
            }
    
            public static string RegExMethod(string img)
            {
                return Regex.Replace(img, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);
            }
    
            public static string SubStringMethod(string img)
            {
                return img.Substring(img.IndexOf(",") + 1);
            }
    
            public static string SplitMethod(string img)
            {
                return img.Split(',')[1];
            }
    
        }
    }
