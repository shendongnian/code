    var row= new System.Web.UI.HtmlControls.HtmlTableRow();
    var cellSID = new System.Web.UI.HtmlControls.HtmlTableCell();
    cellSID.InnerText = sid;
    row.Cells.Add(cellSID);
    
     var cellSName = new System.Web.UI.HtmlControls.HtmlTableCell();
     cellSID.InnerText = sname;
     row.Cells.Add(cellSName);
    
     tblStudents.Rows.Insert(0, row);
