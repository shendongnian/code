    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace AUV_Topology 
    {
        class Program
        {
            public static object[] PopulationChromosomes = {
                                         new int[,] {
                                            { 1,0,0,1},
                                            { 1,0,0,1},
                                            { 1,1,0,1},
                                            { 0,1,1,0}
                      },                 
                                         new int[,] {
                                            { 1,1,0,0},
                                            { 1,1,0,1},
                                            { 0,0,0,0},
                                            { 1,0,0,1}
                      },
                                        new int[,] {
                                            { 0,0,1,0},
                                            { 1,0,0,1},
                                            { 0,0,0,1},
                                            { 1,1,1,0}
                      },
                                        new int[,] {
                                            { 0,0,1,1},
                                            { 1,1,0,1},
                                            { 0,0,1,0},
                                            { 1,0,1,1}
                      },
                                        new int[,] {
                                            { 1,1,0,0},
                                            { 0,1,1,1},
                                            { 1,1,1,1},
                                            { 0,0,1,0}
                      },
                                        new int[,] {
                                            { 1,0,0,1},
                                            { 0,1,1,1},
                                            { 0,1,1,0},
                                            { 1,1,1,1}
                      },
                                       new int[,] {
                                            { 0,0,0,0},
                                            { 1,1,0,0},
                                            { 0,0,0,0},
                                            { 0,1,1,0}
                      }
            };
            public static int[] auvChromosomeLocationsIndexesX = { 2,2,2,2,1,3,2 };
            public static int[] auvChromosomeLocationsIndexesY = { 1,1,1,1,3,2,3 };
            const string FILENAME = @"C:/temp/TreeParser.txt";
            static void Main(string[] args)
            {
                StreamWriter sw = new StreamWriter(FILENAME);
                int tt = 0;
                foreach (int[,] chromosome in PopulationChromosomes)
                {
                    new SpanningTree(auvChromosomeLocationsIndexesY[tt], auvChromosomeLocationsIndexesX[tt], chromosome);
                    SpanningTree.OrderHighLow(SpanningTree.root, 0);
                    SpanningTree.Print(SpanningTree.root, 0, tt,sw);
                    tt++;
                }
                sw.Flush();
                sw.Close();
                Console.ReadLine();
            }
        }
            /* Class Cell */ 
        /*****************************************************************************************************************************/ 
        public class Cell 
        { 
            public int row { get; set; } 
            public int col { get; set; } 
            public int value { get; set; } 
            public Boolean visited { get; set; } 
        } 
        /* Class EnumCell */ 
        /*****************************************************************************************************************************/ 
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
                this.position = LOCATIONS.RESET;
                } 
            public enum XY 
            { 
                Y = 0, //row 
                X = 1 //col 
            } 
            public enum LOCATIONS : byte 
            { 
                RESET = 0xFF,
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
            private static List<List<int>> offsets = new List<List<int>>() { 
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
            /* Class Current Cell */ 
            /*****************************************************************************************************************************/ 
            public Cell Current 
            { 
                get 
                { 
                    try 
                    { 
                    // move to first valid postion
                        if (position == LOCATIONS.RESET) position = LOCATIONS.TOP_LEFT;
                        for (LOCATIONS location = position; location < LOCATIONS.END; location++) 
                        { 
                            if ((row + offsets[(byte)location][(int)XY.Y] >= 0) && (row + offsets[(byte)location][(int)XY.Y] < numberOfRows) && 
                            (col + offsets[(byte)location][(int)XY.X] >= 0) && (col + offsets[(byte)location][(int)XY.X] < numberOfCols)) 
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
                    (col + x >= 0) && (col + x < numberOfCols)) 
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
                position = LOCATIONS.RESET; 
            } 
            public void Dispose() 
            { 
            } 
        } 
        /* Class Graph */ 
        /*****************************************************************************************************************************/ 
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
        /* Class SpanningTree */ 
        /*****************************************************************************************************************************/ 
        class SpanningTree 
        {
            public static Graph graph = null; 
            public static SpanningTree root = new SpanningTree(); 
            public static int counter = 0; 
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
                if ((currentCell.col == 1) && (currentCell.row == 3)) { int z = 5; }
                if ((currentCell.col == 0) && (currentCell.row == 2)) { int zz = 5; }
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
                if (parent.children != null) 
                { 
                    parent.children = parent.children.OrderByDescending(x => x.length).ToList(); 
                    foreach (SpanningTree child in parent.children) 
                    { 
                        OrderHighLow(child, level + 1); 
                    } 
                } 
            } 
            public static void Print(SpanningTree parent, int level,int chromosomeNum, StreamWriter sw) 
            { 
                sw.WriteLine("------------------- Chromosome : {0} -------------------", chromosomeNum); 
                Print(parent, level, sw); 
                sw.WriteLine("---------Longest----------"); 
                PrintLongest(parent, level, sw); 
                counter = 0; 
            } 
            private static void Print(SpanningTree parent, int level, StreamWriter sw) 
            { 
                ////////////////////////////////////////////////////////////////////// 
                sw.WriteLine("{0}Level : '{1}', Row : '{2}', Col : '{3}', Length : '{4}'", new string(' ', 4 * level), level, parent.row, parent.col, parent.length); 
                ////////////////////////////////////////////////////////////////////// 
                if (parent.children != null)
                {
                    foreach (SpanningTree child in parent.children)
                    {
                        Print(child, level + 1, sw);
                        if (child.length == 0)
                        {
                            sw.WriteLine("||,,,,,,Branch {0},,,,,,||", counter);
                            sw.WriteLine("{0}Level : '{1}', Row : '{2}', Col : '{3}', Length : '{4}'", new string(' ', 4 * level), level, root.row, root.col, root.length);
                            counter += 1;
                        }
                    }
                }
                   
            } 
            public static void PrintLongest(SpanningTree parent, int level,StreamWriter sw) 
            { 
                ////////////////////////////////////////////////////////////////////// 
                sw.WriteLine("{0}Level : '{1}', Row : '{2}', Col : '{3}', Length : '{4}'", new string(' ', 4 * level), level, parent.row, parent.col, parent.length); 
                ////////////////////////////////////////////////////////////////////// 
                if (parent.children != null) 
                { 
                    PrintLongest(parent.children[0], level + 1,sw); 
                } 
            } 
        }
    }// end name space
      
