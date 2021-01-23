    int MineInfo(int index, int rows, int columns)
    {
        int centerRow = index / rows, centerColumn = index % columns,
            result = 0;
        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
            {
                // Ignore the center cell
                if (i == 0 && j == 0)
                {
                    continue;
                }
                int checkRow = centerRow + i, checkColumn = centerColumn + j;
                // Ignore cells not within the game board
                if (checkRow < 0 || checkRow >= rows ||
                    checkColumn < 0 || checkColumn >= columns)
                {
                    continue;
                }
                int checkIndex = checkRow * columns + checkColumn;
                if (mines.Contains(checkIndex))
                {
                    result++;
                }
            }
        return result;
    }
