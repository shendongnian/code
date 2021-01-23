    public void Page_Init(object sender, EventArgs e)
    {
        // cell
        var cell = new System.Web.UI.WebControls.TableCell();
        cell.ID = "cell";
    
        // cell in row
        var row = new System.Web.UI.WebControls.TableRow();
        row.Controls.Add(cell);
    }
