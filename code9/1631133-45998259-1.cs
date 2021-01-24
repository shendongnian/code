    using System;
    using System.Collections.Generic;
    
    namespace Frames
    {
    	class Program
    	{
    		static SortedSet<string> output = new SortedSet<string>();
    
    		static void Main()
    		{
    			var n = int.Parse(Console.ReadLine());
    			var frames = new Tuple<int, int>[n];
    
    			for (int i = 0; i < n; i++)
    			{
    				var strs = Console.ReadLine().Split(' ');
    				frames[i] = new Tuple<int, int>(int.Parse(strs[0]), int.Parse(strs[1]));
    			}
    
    			Recursion(frames, 0, new Tuple<int, int>[n], new bool[n]);
    
    			Console.WriteLine(output.Count);
    			Console.WriteLine(string.Join(Environment.NewLine, output));
    		}
    
    		static void Recursion(Tuple<int, int>[] frames, int position, Tuple<int, int>[] current, bool[] used)
    		{
    			if (position == frames.Length)
    			{
    				output.Add(string.Join(" | ", (IEnumerable<Tuple<int, int>>)current));
    				return;
    			}
    
    			for (int i = 0; i < frames.Length; i++)
    			{
    				if (used[i])
    				{
    					continue;
    				}
    
    				used[i] = true;
    
    				current[position] = frames[i];
    				Recursion(frames, position + 1, current, used);
    
    				current[position] = new Tuple<int, int>(frames[i].Item2, frames[i].Item1);
    				Recursion(frames, position + 1, current, used);
    
    				used[i] = false;
    			}
    		}
    	}
    }
