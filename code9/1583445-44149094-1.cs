    // To keep track of the previous row Group Identifier
    string strPreviousRowID = string.Empty;
    // To keep track the Index of Group Total
    int intSubTotalIndex = 1;
    string strGroupHeaderText = string.Empty;
    // To temporarily store Sub Total
    double dblSubTotalUnitPrice = 0;
    double dblSubTotalQuantity = 0;
    double dblSubTotalDiscount = 0;
    double dblSubTotalAmount = 0;
    // To temporarily store Grand Total
    double dblGrandTotalUnitPrice = 0;
    double dblGrandTotalQuantity = 0;
    double dblGrandTotalDiscount = 0;
    double dblGrandTotalAmount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Event fires for every row creation
    /// Used for creating SubTotal row when next group starts by adding Group Total at previous row manually
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdViewOrders_RowCreated(object sender, GridViewRowEventArgs e)
    {
        bool IsSubTotalRowNeedToAdd = false;
        bool IsGrandTotalRowNeedtoAdd = false;
        if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "CustomerID") != null))
            if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "CustomerID").ToString())
                IsSubTotalRowNeedToAdd = true;
        if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "CustomerID") == null))
        {
            IsSubTotalRowNeedToAdd = true;
            IsGrandTotalRowNeedtoAdd = true;
            intSubTotalIndex = 0;
        }
        #region Getting the first Group Header Text
        if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "CustomerID") != null))
            strGroupHeaderText = DataBinder.Eval(e.Row.DataItem, "CompanyName").ToString();
        #endregion
        if (IsSubTotalRowNeedToAdd)
        {
            #region Adding Sub Total Row
            GridView grdViewOrders = (GridView)sender;
            // Creating a Row
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
            //Adding Group Expand Collapse Cell 
            TableCell cell = new TableCell();
            row.Cells.Add(cell);
            //Adding Expand Collapse Cell 
            cell = new TableCell();
            System.Web.UI.HtmlControls.HtmlImage img = new System.Web.UI.HtmlControls.HtmlImage();
            img.Src = "images/minus.gif";
            img.Attributes.Add("alt", strPreviousRowID);
            img.Attributes.Add("class", "ExpandCollapseStyle");
            cell.Controls.Add(img);
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Header Cell 
            cell = new TableCell();
            cell.Text = strGroupHeaderText;
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.ColumnSpan = 2;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Unit Price Column
            cell = new TableCell();
            cell.Text = string.Format("{0:0.00}", dblSubTotalUnitPrice);
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Quantity Column
            cell = new TableCell();
            cell.Text = string.Format("{0:0.00}", dblSubTotalQuantity);
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Discount Column
            cell = new TableCell();
            cell.Text = string.Format("{0:0.00}", dblSubTotalDiscount);
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Amount Column
            cell = new TableCell();
            cell.Text = string.Format("{0:0.00}", dblSubTotalAmount);
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);
            //Adding the Row at the RowIndex position in the Grid
            grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
            intSubTotalIndex++;
            #endregion
            #region Getting Next Group Header Details
            if (DataBinder.Eval(e.Row.DataItem, "CustomerID") != null)
                strGroupHeaderText = DataBinder.Eval(e.Row.DataItem, "CompanyName").ToString();
            #endregion
            #region Reseting the Sub Total Variables
            dblSubTotalUnitPrice = 0;
            dblSubTotalQuantity = 0;
            dblSubTotalDiscount = 0;
            dblSubTotalAmount = 0;
            #endregion
        }
        if (IsGrandTotalRowNeedtoAdd)
        {
            #region Grand Total Row
            GridView grdViewOrders = (GridView)sender;
            // Creating a Row
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
            //Adding Group Expand Collapse Cell 
            TableCell cell = new TableCell();
            System.Web.UI.HtmlControls.HtmlImage img = new System.Web.UI.HtmlControls.HtmlImage();
            img.Src = "images/minus.gif";
            img.Attributes.Add("class", "ExpandCollapseGrandStyle");
            img.Attributes.Add("alt", "Expanded");
            cell.Controls.Add(img);
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.CssClass = "GrandTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Expand Collapse Cell 
            cell = new TableCell();
            cell.CssClass = "GrandTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Header Cell 
            cell = new TableCell();
            cell.Text = "Grand Total";
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.ColumnSpan = 2;
            cell.CssClass = "GrandTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Unit Price Column
            cell = new TableCell();
            cell.Text = string.Format("{0:0.00}", dblGrandTotalUnitPrice);
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.CssClass = "GrandTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Quantity Column
            cell = new TableCell();
            cell.Text = string.Format("{0:0.00}", dblGrandTotalQuantity);
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.CssClass = "GrandTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Discount Column
            cell = new TableCell();
            cell.Text = string.Format("{0:0.00}", dblGrandTotalDiscount);
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.CssClass = "GrandTotalRowStyle";
            row.Cells.Add(cell);
            //Adding Amount Column
            cell = new TableCell();
            cell.Text = string.Format("{0:0.00}", dblGrandTotalAmount);
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.CssClass = "GrandTotalRowStyle";
            row.Cells.Add(cell);
            //Adding the Row at the RowIndex position in the Grid
            grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex, row);
            #endregion
        }
    }
    /// <summary>
    /// Event fires when data binds to each row
    /// Used for calculating Group Total 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdViewOrders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // This is for cumulating the values
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "CustomerID").ToString();
            double dblUnitPrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UnitPrice").ToString());
            double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Quantity").ToString());
            double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Discount").ToString());
            double dblAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount").ToString());
            // Cumulating Sub Total
            dblSubTotalUnitPrice += dblUnitPrice;
            dblSubTotalQuantity += dblQuantity;
            dblSubTotalDiscount += dblDiscount;
            dblSubTotalAmount += dblAmount;
            // Cumulating Grand Total
            dblGrandTotalUnitPrice += dblUnitPrice;
            dblGrandTotalQuantity += dblQuantity;
            dblGrandTotalDiscount += dblDiscount;
            dblGrandTotalAmount += dblAmount;
            e.Row.Style.Add("display", "block");
            e.Row.CssClass = "ExpandCollapse" + strPreviousRowID;
        }
    }
