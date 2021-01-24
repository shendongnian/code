    List<DataGridViewRow> listofrows = new List<DataGridViewRow>();//we'll agregate our desired rows in this
    //itterate through the rows of the DataGridView
    foreach (DataGridViewRow item in dgv1.Rows)
    {
        DataGridViewRow r = (DataGridViewRow)item.Clone();//clone the desired row
        //Oddly enough... cloning does not clone the values... So lets put the values back in their cells
        for (int i = 0; i < item.Cells.Count; i++)
        {
            r.Cells[i].Value = item.Cells[i].Value;
        }
        listofrows.Add(r);//add the row to the list
    }
