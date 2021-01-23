      public static class TreeAndNodeExtensions
      {
        public static void Write<T>(this Tree<T> tree)
        {
          var baseMaxNodes = Convert.ToInt32(Math.Pow(2, tree.Levels - 1));
    
          // determine the required node width based on the the last two levels and their value lengths...
          var nodeWidth = Math.Max(tree.Values.Skip(Convert.ToInt32(Math.Pow(2, tree.Levels - 2) - 1)).Max(n => n.ToString().Length), tree.Values.Skip(Convert.ToInt32(Math.Pow(2, tree.Levels - 1) - 1)).Max(n => n.ToString().Length) + 1) + 1;
    
          var baseWidth = baseMaxNodes * nodeWidth;
          Console.CursorLeft = baseWidth/2;
          tree.Root.Write(baseWidth);
        }
    
        private static void Write<T>(this Node<T> node, int nodeWidth, int level=0)
        {
          var cl = Console.CursorLeft;
          var ct = Console.CursorTop;
    
          if (Console.CursorLeft >= Convert.ToInt32(Math.Ceiling(node.Data.ToString().Length / 2.0)))
          {
            Console.CursorLeft -= Convert.ToInt32(Math.Ceiling(node.Data.ToString().Length / 2.0));
          }
          Console.Write(node.Data);
          if (node.Left != null)
          {
            var numCenter = cl - nodeWidth/4;
            Console.CursorLeft = numCenter;
            Console.CursorTop = ct + 2;
            Console.Write('/');
            Console.CursorTop = ct + 1;
            Console.Write(new string('_',cl-Console.CursorLeft));
            Console.CursorLeft = numCenter;
            Console.CursorTop = ct+3;
            node.Left.Write(nodeWidth/2, level+1);
          }
    
          if (node.Right != null)
          {
            var numCenter = cl + nodeWidth/4;
            Console.CursorLeft = cl;
            Console.CursorTop = ct + 1;
            Console.Write(new string('_', numCenter-cl-1));
            Console.CursorTop = ct + 2;
            Console.Write('\\');
            Console.CursorLeft = numCenter;
            Console.CursorTop = ct+3;
            node.Right.Write(nodeWidth/2,level + 1);
          }
          
          Console.SetCursorPosition(cl,ct);
        }
      }
