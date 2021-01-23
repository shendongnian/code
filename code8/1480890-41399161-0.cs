    protected void Page_Load(object sender, EventArgs e)
    {        
         if (!IsPostBack)
         {
             GridReport.DataSource = <your datatable>;
             // This is the table I shown in Figure 1.1
    
             GridReport.DataBind();
    
             // Your other codes here (if any)
         }
    }
    
    protected void btnTransposeReport_Click(object sender, EventArgs e)
    {
         DataTable inputTable = <your datatable>;
         // Table shown in Figure 1.1
    
         DataTable transposedTable = GenerateTransposedTable(inputTable);
    
         GridReport.DataSource = transposedTable;
         // Table shown in Figure 1.2
    
         GridReport.DataBind();
    }
    
    private DataTable GenerateTransposedTable(DataTable inputTable)
    {
         DataTable outputTable = new DataTable();
    
         // Add columns by looping rows
    
         // Header row's first column is same as in inputTable
         outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());
    
         // Header row's second column onwards, 'inputTable's first column taken
         foreach (DataRow inRow in inputTable.Rows)
         {
             string newColName = inRow[0].ToString();
             outputTable.Columns.Add(newColName);
         }
    
         // Add rows by looping columns        
         for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
         {
             DataRow newRow = outputTable.NewRow();
    
             // First column is inputTable's Header row's second column
             newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
             for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
             {
                 string colValue = inputTable.Rows[cCount][rCount].ToString();
                 newRow[cCount + 1] = colValue;
             }
             outputTable.Rows.Add(newRow);
         }
    
         return outputTable;
    }
