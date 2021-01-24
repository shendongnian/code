     using System.Linq;
     ...  
     string[] data = Enumerable
       .Range(1, 9)                                   // 9 rows, starting from 1
       .Select(row => string.Join(" ", Enumerable     // cols are joined with space
          .Range(1, 5)                                // 5 columns in each row
          .Select(col => ws.Cells[row, col].Value2)))
       .ToArray();
