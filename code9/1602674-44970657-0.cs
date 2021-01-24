    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Auv_Topology
    {
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
