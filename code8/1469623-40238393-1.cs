    using System.Collections.Generic;
    class Program {
        private static IEnumerable<List<char>> GetSubCombinations(char[] elements, uint startingPos)
        {
            // Leaf condition
            if (startingPos == elements.Length - 1)
            {
                yield return new List<char> {elements[startingPos]};
                yield return new List<char>();
                yield break;
            }
            // node splitting
            foreach (var list in GetSubCombinations(elements, startingPos + 1))
            {
                yield return list;
                list.Add(elements[startingPos]);
                yield return list;
                list.Remove(elements[startingPos]);
            }
        }
        private static IEnumerable<List<char>> GetPartialCombinations(char[] elements)
        {
            foreach (var c in GetSubCombinations(elements, 0))
            {
                // Here you can filter out trivial combinations,
                // e.g. all elements, individual elements and the empty set
                if (c.Count > 1 && c.Count < elements.Length)
                    yield return c;
            }
        }
        static void Main(string[] args) {
            char[] elements = new char[] {'A', 'B', 'C'};
            foreach (var combination in GetPartialCombinations(elements))
            {
                foreach (char elem in combination)
                    System.Console.Write(elem + ", ");
                System.Console.Write("\n");
            }
		    return;
	    }
	
    }
