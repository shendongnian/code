    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class static Program {
        
        public static void Main() 
        {
            var terms = new List<Term>();
            
            var result = ((int?)terms.FirstOrDefault().Deadline ?? 0);        
            Console.WriteLine(result);
            
            var result2 = (terms.FirstOrDefault()?.Deadline ?? 0);
            Console.WriteLine(result2);
        }
        
        private class Term
        {
         	public int Deadline { get; set; }
        }
    }
