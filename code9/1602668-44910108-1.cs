    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static int[,] graph = {
                                            { 0,0,1,1},
                                            { 0,0,1,1},
                                            { 1,0,1,0},
                                            { 1,0,0,1},
                                       };
            static void Main(string[] args)
            {
                new SpanningTree(0, 2, graph);
                SpanningTree.OrderHighLow(SpanningTree.root, 0);
                SpanningTree.Print(SpanningTree.root, 0);
                Console.WriteLine("Longest");
                SpanningTree.PrintLongest(SpanningTree.root, 0);
                Console.ReadLine();
            }
        }
        public class SpanningTree
        {
            public static Graph graph = null;
            public static SpanningTree root = new SpanningTree();
            public int row { get; set; }
            public int col { get; set; }
            public int length { get; set; }
            public List<SpanningTree> children { get; set; }
            public SpanningTree() { }
            public SpanningTree(int startRow, int startCol, int[,] graph)
            {
                SpanningTree.graph = new Graph(graph);
                RecursiveTree(root, SpanningTree.graph.graph[startRow][startCol]);
            }
            public int RecursiveTree(SpanningTree parent, Cell currentCell)
            {
                int length = 0;
                int maxLength = 0;
                parent.row = currentCell.row;
                parent.col = currentCell.col;
                graph.graph[currentCell.row][currentCell.col].visited = true;
                EnumCell enumCell = new EnumCell(currentCell.row, currentCell.col, graph.graph);
                foreach (Cell cell in enumCell)
                {
                    if (!cell.visited)
                    {
                        SpanningTree newBranch = new SpanningTree();
                        if (parent.children == null) parent.children = new List<SpanningTree>();
                        parent.children.Add(newBranch);
                        length = RecursiveTree(newBranch, SpanningTree.graph.graph[cell.row][cell.col]);
                        if (length > maxLength) maxLength = length;
                    }
                }
                graph.graph[currentCell.row][currentCell.col].visited = false;
                parent.length = maxLength;
                return maxLength + 1;
            }
            public static void OrderHighLow(SpanningTree parent, int level)
            {
                parent.children = parent.children.OrderByDescending(x => x.length).ToList();
                if (parent.children != null)
                {
                    foreach (SpanningTree child in parent.children)
                    {
                        Print(child, level + 1);
                    }
                }
            }
            public static void Print(SpanningTree parent, int level)
            {
                Console.WriteLine("{0}Level : '{1}', Row : '{2}', Col : '{3}', Length : '{4}'", new string(' ', 4 * level), level, parent.row, parent.col, parent.length);
                if (parent.children != null)
                {
                    foreach (SpanningTree child in parent.children)
                    {
                        Print(child, level + 1);
                    }
                }
            }
            public static void PrintLongest(SpanningTree parent, int level)
            {
                Console.WriteLine("{0}Level : '{1}', Row : '{2}', Col : '{3}', Length : '{4}'", new string(' ', 4 * level), level, parent.row, parent.col, parent.length);
                if (parent.children != null)
                {
                    PrintLongest(parent.children[0], level + 1);
                }
            }
        }
        public class Graph
        {
            public Graph(int[,] graph)
            {
                this.graph = new List<List<Cell>>();
                for (int row = 0; row < graph.GetLength(0); row++)
                {
                    List<Cell> newRow = new List<Cell>();
                    this.graph.Add(newRow);
                    for (int col = 0; col < graph.GetLength(1); col++)
                    {
                        Cell newCell = new Cell();
                        newRow.Add(newCell);
                        newCell.row = row;
                        newCell.col = col;
                        newCell.value = graph[row, col];
                        newCell.visited = false;
                    }
                }
            }
            public List<List<Cell>> graph;
        }
        public class Cell
        {
            public int row { get; set; }
            public int col { get; set; }
            public int value { get; set; }
            public Boolean visited { get; set; }
        }
        public class EnumCell : IEnumerator<Cell>
        {
            public EnumCell() { }
            public EnumCell(int startRow, int startCol, List<List<Cell>> graph)
            {
                this.row = startRow;
                this.col = startCol;
                this.numberOfRows = graph.Count;
                this.numberOfCols = graph[0].Count;
                this.graph = graph;
            }
            public enum XY
            {
                Y = 0,  //row
                X = 1   //col
            }
            public enum LOCATIONS : byte
            {
                TOP_LEFT = 0,
                TOP_MIDDLE,
                TOP_RIGHT,
                LEFT,
                RIGHT,
                BOTTOM_LEFT,
                BOTTOM_MIDDLE,
                BOTTOM_RIGHT,
                END,
                INVALID
            }
            public List<List<Cell>> graph { get; set; }
            public int row { get; set; }
            public int col { get; set; }
            public int numberOfRows { get; set; }
            public int numberOfCols { get; set; }
            //offsets are in same order as enum location as y-offset(row), x-offset (col)
            private List<List<int>> offsets = new List<List<int>>() {
                new List<int>() { -1, -1 },
                new List<int>() { -1, 0 },
                new List<int>() { -1, +1 },
                new List<int>() { 0, -1 },
                new List<int>() { 0, +1 },
                new List<int>() { +1, -1 },
                new List<int>() { +1, 0 },
                new List<int>() { +1, +1 }
            };
            public LOCATIONS position { get; set; }
            public EnumCell GetEnumerator()
            {
                return new EnumCell(row, col, graph);
            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public Cell Current
            {
                get
                {
                    try
                    {
                        // move to first valie postion
                        for (LOCATIONS location = position; location < LOCATIONS.END; location++)
                        {
                            if ((row + offsets[(byte)location][(int)XY.Y] >= 0) && (row + offsets[(byte)location][(int)XY.Y] < numberOfRows) &&
                                (col + offsets[(byte)location][(int)XY.X] > 0) && (col + offsets[(byte)location][(int)XY.X] < numberOfCols))
                            {
                                position = (LOCATIONS)location;
                                int newRow = row + offsets[(byte)location][(int)XY.Y];
                                int newCol = col + offsets[(byte)location][(int)XY.X];
                                return graph[newRow][newCol];
                            }
                        }
                        throw new InvalidOperationException();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            public Boolean MoveNext()
            {
                Boolean results = false;
                for (LOCATIONS location = ++position; location < LOCATIONS.END; location++)
                {
                    int y = offsets[(byte)location][(int)XY.Y];
                    int x = offsets[(byte)location][(int)XY.X];
                    if ((row + y >= 0) && (row + y < numberOfRows) &&
                        (col + x > 0) && (col + x < numberOfCols))
                    {
                        if (graph[row + y][col + x].value == 1)
                        {
                            position = (LOCATIONS)location;
                            return true;
                        }
                    }
                }
                return results;
            }
            public void Reset()
            {
                position = LOCATIONS.TOP_LEFT;
            }
            public void Dispose()
            {
            }
        }
    }
