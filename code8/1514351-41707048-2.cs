      static void Orginal(int[] array)
            {            
                string numbers = "";
                for (int i = 0; i < array.Count(); i++)
                {
                    numbers += i.ToString();
                }
            }
    
            static void Improved(int[] array)
            {
                var numbers = new StringBuilder();
                for (int i = 0; i < array.Length; i++)
                {
                    numbers.Append(i);
                }
            }
    
            static void Alternate(int[] array)
            {
                var strings = array.Select(n => n.ToString()).ToArray();
                var s = string.Join("", strings);
            }
            static void Alternate2(int[] array)
            {
                string.Concat(array);
            }
            static void Time(string name, Action<int[]> action, int[] array)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                action(array);
                stopwatch.Stop();
                Console.WriteLine("{0} - {1}", name, stopwatch.ElapsedMilliseconds);
            }
    
           static void Main(string[] args)
           {
              var array = Enumerable.Range(0, 100000).ToArray();
              Time("Original", Orginal, array); 
              Time("Improved", Improved, array); 
              Time("Alternate", Alternate,array);
              Time("Alternate2", Alternate2,array);
              
           }
