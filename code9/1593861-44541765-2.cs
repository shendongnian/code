    var hl = new HyperLink();
    hl.Text = status;
    hl.ID = "myLink";
    hl.Style.Add(HtmlTextWriterStyle.Color, (disabled ? "red" : "green"));
    hl.NavigateUrl = "#";
    cell.Controls.Add(hl);
    tr.Cells.Add(cell);
