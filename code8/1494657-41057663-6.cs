    using System;
    using System.Collections.Generic;
    class Program {
    	public static int GetCombinations(int total, int index, int[] list, List<int> cur) {  
    		if (total == 0) {
    			foreach(var i in cur) {
    				Console.Write(i + " ");
    			}
    			Console.WriteLine();
    			return 1;
    		}
    		if(index == list.Length) {
    			return 0;
    		}
    		int ret = 0;
    		for(; total >= 0; total -= list[index]) {
    			ret += GetCombinations(total, index + 1, list, cur);
    			cur.Add(list[index]);
    		}
    		for(int i = 0; i < cur.Count; i++) {
    			while(cur.Count > i && cur[i] == list[index]) {
    				cur.RemoveAt(i);
    			}
    		}
    		return ret;
    	}
        public static void Main() {
        	int[] l = { 5, 10, 20, 50, 100, 200, 500 };
        	GetCombinations(20, 0, l, new List<int>());
        }
    }
