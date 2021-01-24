    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1 {
    	class Program {
    		static void Main(string[] args) {
    			string[,] array1 = { { "123", "09/17/17" }, { "456", "09/17/17" }, { "789", "09/18/17" } };
    			string[,] array2 = { { "147", "09/17/17" }, { "789", "09/20/17" }, { "123", "09/19/17" } };
    			//Output: string[,] array 3 = {456, 09/17/17}
    
    			List<string> keys = new List<string>();
    			Dictionary<string, string> output = new Dictionary<string, string>();
    
    			// grab the first-dimension values
    			for(int index =0; index < array2.GetLength(0);index++) {
    				keys.Add( array2[index, 0]);
    			}
    
    			// compare they first-dimension values that we extracted to the first-dimension values in the 
    			// source array.  If no match is found, then it is not a duplicate entry, so record it in
    			// the output container.
    			for (int index = 0; index < array1.GetLength(0); index++) {
    				if (!keys.Contains(array1[index,0])) {
    					output.Add(array1[index, 0], array1[index, 1]);
    				}
    			}
    
    			// transforming the output Dictionary<> into a 2D array is left as an excersize for the reader.
    
    			// print output
    			foreach(var key in output.Keys) {
    				Console.WriteLine($"{key}: {output[key]}");
    			}
    			Console.ReadKey(true);
    		}
    	}
    }
