    for (rowCtr = 1; rowCtr <= rowCnt; rowCtr++)
            {
                // Create a new row and add it to the table.
                TableRow tRow1 = new TableRow();
                table.Rows.Add(tRow1);
                for (cellCtr = 1; cellCtr <= cellCnt; cellCtr++)
                {
                    // Create a new cell and add it to the row.
                    TableCell tCell = new TableCell();
                    tRow1.Cells.Add(tCell);
                    // Create a Hyperlink Web server control and add it to the cell.
                    System.Web.UI.WebControls.HyperLink hyp = new HyperLink();
                    hyp.Text = rowCtr.ToString();
                    hyp.ID = "hyp_"+rowCtr+cellCtr;
                    hyp.NavigateUrl = "http://www.microsoft.com/net";
                    tCell.Controls.Add(hyp);
                    HiddenField hid = new HiddenField();
                    hid.ID = "hdn_" + rowCtr + cellCtr;
                    tCell.Controls.Add(hid);
                    Label lbll = new Label();
                    lbll.ID = "lblError_" + rowCtr + cellCtr;
                    lbll.ForeColor = System.Drawing.Color.Red;
                    tCell.Controls.Add(lbll);
                }
            }
