    using System;
    using System.Linq;
    
    namespace stack
    {
        class Program
        {
            static void Main(string[] args)
    		{
                decimal changeAvil = 10;
                var noteSet = "1usd,5usd,10usd,20usd";
                var notes = noteSet.Split(',');
                var dict = notes.ToDictionary(x => int.Parse(new string(x.TakeWhile(c => char.IsNumber(c)).ToArray())), x => x);
    
                var selection = dict.Where(kvp => kvp.Key <= changeAvil).Select(kvp => kvp.Value).ToList();
                foreach (var s in selection) {
                    Console.WriteLine(s);
                }
                    
            }
        }
    }
