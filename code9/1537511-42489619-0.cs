        using System.Linq;
        ...
    	private int _CurentPageNumber = 0;
    
    	private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    	{
    		y = 80;
    		itemperpage = 0;
    		_CurentPageNumber = 0;
    	}
    
    	private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    	{
    		_CurentPageNumber++;
    
    		int skip = (_CurentPageNumber - 1) * itemperpage;
    
    		var query = dt.AsEnumerable().Skip(skip).Take(itemperpage);
    
    		foreach (DataRow row in query.CopyToDataTable().Rows)
    		{
    			e.Graphics.DrawString(row[4].ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, y, new StringFormat());
    		}
    	}
