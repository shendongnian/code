    List<int> ids = new List<int>();
    foreach (GridViewRow gRow in grvList.Rows)
    {
       CheckBox chkbox = (CheckBox)gRow.FindControl("chk");
       if (chkbox.Checked)
       {
          int id = Convert.ToInt32(gRow.Cells[1].Text);
                    editPageUrl = "http://ycchoi/sites/dev/_layouts/15/ListItemControl/EditListItem.aspx?ID=" + id;
          ids.Add(id);
        }
    }
    if (ids.Count == 1)
    {
        // do something with ids[0]
    }
    else
    {
        // show error
    }
