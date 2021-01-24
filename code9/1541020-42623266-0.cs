     public static double GetDistance(int x0, int y0, int x1, int y1)
            {
                // mirror image dictionary to manipulate the parallel columns
                Dictionary<int, int> mirrorMatrixCols = new Dictionary<int, int>();
                mirrorMatrixCols.Add(0, 7);
                mirrorMatrixCols.Add(1, 8);
                mirrorMatrixCols.Add(2, 9);
                mirrorMatrixCols.Add(3, 10);
                mirrorMatrixCols.Add(4, 11);
                mirrorMatrixCols.Add(5, 12);
                mirrorMatrixCols.Add(6, 13);
    
                var result = 0;
                // the distance of cells to the point of y1 column
                result = (x1 - x0) * 7;
                // add the distance to the manipulated column
                result = result + (mirrorMatrixCols[y1] - y0);
                return result;    
            }
