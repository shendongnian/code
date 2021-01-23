    // the reference to the enumerator for the DataRows
    IEnumerator rows;
    private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        var dataTable = Load();
        rows = dataTable.Rows.GetEnumerator();
    }
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        // no rows, no glory
        if (rows == null) return;
        // keep track of stuff
        var chartsOnthisPage = 0;
        var yPos = 20f;
        // loop for what needs to go on this page, atm it prints 2 charts
        // as long as there are rows
        // the enumerator is moved to the next record ...
        while ((e.HasMorePages = rows.MoveNext()))
        {
            // ... get hold of that datarow 
            var currentRow = (DataRow)rows.Current;
            // print
            e.Graphics.DrawString(currentRow[0].ToString(), Font, Brushes.Black, 0, yPos);
            // keep track where we are
            yPos = yPos + 40;
            // do what ever is need to print the chart fro this row
            GenerateChart(currentRow);
            // print the chart
            chart1.Printing.PrintPaint(e.Graphics, new Rectangle(0, (int)yPos, 200, 200));
            // position tracking
            yPos = yPos + 200;
            // optionaly break here if we reached the end of the page
            // keep track 
            chartsOnthisPage++;
            if (chartsOnthisPage > 1) break; // HasMorePages is set
        }
    }
    private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
       // clean up;
        rows = null;  
    }
