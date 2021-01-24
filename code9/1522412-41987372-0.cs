    public static int LastRow { get; set; }
    public static int LastColumn { get; set; }
    public static void PublishToSheet(this WorksheetBase theSheet, 
                                      int startRow, 
                                      int startColumn, 
                                      ref string[,] OutputArray)
    {
        var totalRows  = OutputArray.GetLength(0);
        var maxColumns = OutputArray.GetLength(1);
        var range = theSheet.Range[theSheet.Cells[startRow, startColumn], 
                                   theSheet.Cells[startRow + totalRows - 1,
                                                  startColumn + maxColumns - 1]
                                  ];
        range.NumberFormat = "@";
        range.Value2 = OutputArray;
        LastRow   = totalRows;
        LastColumn = maxColumns;
    }
