    int numRows = 4;
    int numColums = 5;
    int cellSize = Random.Range(0,4);
    for (int iRow = 0; iRow < numRows; iRow++) {
        for (int iCol = 0; iCol <numColums ; iCol++) {
            // HERE
            test.gridData[iRow][iCol].MyVal= val;
        }
    }
