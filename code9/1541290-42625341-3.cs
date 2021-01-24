    private static bool CheckPattern(int?[,] temp, int[,] data, out int row, out int col)
    {
        int rowsT = temp.GetLength(0);
        int colsT = temp.GetLength(1);
        int rowsD = data.GetLength(0);
        int colsD = data.GetLength(1);
        // Find the "maximum" value of the template (how many different
        // condition are there... If there is only "X" then 1, "X", "Y" then 2,
        // "X", "Y", "Z" then 3...
        int max = -1;
        for (int i = 0; i < rowsT; i++)
        {
            for (int j = 0; j < rowsT; j++)
            {
                if (temp[i, j] != null)
                {
                    max = Math.Max(temp[i, j].Value, max);
                }
            }
        }
        // We save in an array the "current" values of "X", "Y", "Z", ...
        int?[] values = new int?[max + 1];
        for (int i = 0; i < rowsD - rowsT + 1; i++)
        {
            for (int j = 0; j < colsD - colsT + 1; j++)
            {
                Array.Clear(values, 0, values.Length);
                bool success = true;
                // Check the template
                for (int k = 0; k < rowsT; k++)
                {
                    for (int r = 0; r < colsT; r++)
                    {
                        if (temp[k, r] != null)
                        {
                            int? curr = values[temp[k, r].Value];
                            if (curr == null)
                            {
                                // If this is the first time we check this
                                // condition, then any value is good
                                values[temp[k, r].Value] = data[i + k, j + r];
                            }
                            else if (curr.Value == data[i + k, j + r])
                            {
                                // For subsequent instances we check this
                                // condition, then the data must have the
                                // value found in the previous instance
                            } 
                            else 
                            {
                                success = false;
                                break;
                            }
                        }
                    }
                    if (!success)
                    {
                        break;
                    }
                }
                if (success)
                {
                    row = i;
                    col = j;
                    return true;
                }
            }
        }
        row = 0;
        col = 0;
        return false;
    }
