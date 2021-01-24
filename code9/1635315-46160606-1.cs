    foreach (GridViewRow row in poGridview.Rows)
    {
        String itemNum = row.Cells[0].Text;        
        String house = row.Cells[2].Text;
        String description = row.Cells[1].Text;
        Paragraph itemLine1 = new Paragraph(@"" + itemNum + "         " + house + "          " + description, body);
        p.Add(itemLine1);   
    }
