    private static void GetStartEndOfLastGroupOfZeros() {
      string readData = "";
      int rowNum = 0;
      List<int> rowsOfZero = new List<int>();
      StreamReader srHexFile = File.OpenText(m_pathHexFile);
      while ((readData = srHexFile.ReadLine()) != null) {
        if (readData.Equals(":0000000000")) {
          rowsOfZero.Add(rowNum);
        }
        rowNum++;
      }
      rowsOfZero.Reverse();
      PrintIndexes(rowsOfZero);
      if (rowsOfZero.Count < 1) {
        Console.WriteLine("There are NO rows that are :0000000000");
      }
      else {
        Console.WriteLine("\n\rStart line number of Last Zero Group: " + GetFirstIndexOfLastGroupOfZeroRows(rowsOfZero));
        Console.WriteLine("End line number of Last Zero Group: " + GetLastIndexOfLastGroupOfZeroRows(rowsOfZero));
      }
    }
    private static int GetFirstIndexOfLastGroupOfZeroRows(List<int> rowsOfZero) {
      if (rowsOfZero.Count < 1)  // <- if there are not any int in the list then there are no zero rows return -1;
        return -1;
      if (rowsOfZero.Count < 2)  // <- if there is only one row then it starts and ends on that single row
          return rowsOfZero[0];
      if (rowsOfZero[1] + 1 != rowsOfZero[0])  // <-- if the second element(1) is not contiguous, then the last row is a single zero row,
        return rowsOfZero[0];                  // <-- so the start line of the last group will be the same as the end line index 
      int startOfThisGroup = 0;
      for (int i = 2; i < rowsOfZero.Count; i++) {
        if (rowsOfZero[i] + 1 == rowsOfZero[i - 1]) {  // <-- if they are contiguous then we have a new startOfThisGroup row, if not we are done checking
          startOfThisGroup = rowsOfZero[i];
        }
        else {
          break;
        }
      }
      return startOfThisGroup;
    }
    private static int GetLastIndexOfLastGroupOfZeroRows(List<int> rowsOfZero) {
      if (rowsOfZero.Count < 1)
        return 0;
      return rowsOfZero[0];
    }
    private static void PrintIndexes(List<int> rowsOfZero) {
      if (rowsOfZero.Count < 1) {
        Console.WriteLine("No zero rows");
      }
      else {
        Console.Write("Sorted (high to low) row indexes that are ':0000000000' -> ");
        foreach (int curInt in rowsOfZero)
          Console.Write(curInt + " ");
      }
      Console.WriteLine("");
    }
