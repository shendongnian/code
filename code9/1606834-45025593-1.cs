        public static void Print(SpanningTree parent, int level)
        {
            FileStream fs = new FileStream("C:/Users/Welcome/Desktop/SpanningTree.txt", FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                Print(parent, level, sw);
            }
        }
        private static void Print(SpanningTree parent, int level, StreamWriter sw)
        {
            sw.WriteLine("----------------------------------------------------------------------------------------");
            sw.WriteLine("{0} Level : '{1}' ", new string(' ', 4 * level), level);
            sw.WriteLine(" , Row : '{0}', Col : '{1}'", parent.row, parent.col);
            sw.WriteLine("Length : '{0}'", parent.length);
            sw.WriteLine("----------------------------------------------------------------------------------------");
            if (parent.children != null)
            {
                foreach (SpanningTree child in parent.children)
                {
                    Print(child, level + 1, sw);
                }
            }
        }
 
