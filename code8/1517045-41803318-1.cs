    public static string[,] csvToArray(string filePath)
        {
            int col = colCount(filePath);
            int row = rowCount(filePath);
            string line;
            string[,] data = new string[row, col];
            using (StreamReader sr = new StreamReader(filePath))
            {
                for (int i = 0; i < row; i++)
                {
                    var tokens = sr.ReadLine().Split(',');
                    for (int j = 0; j < col; j++)
                    {
                        data[i, j] = tokens[j];
                    }
                }
            }
            return data;
        }
