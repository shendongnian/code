    var columns = GridView1.Columns.CloneFields(); // makes a copy of gridview columns
    GridView1.Columns.Clear(); // remove all the columns
    // now make any order for your gridview columns
    GridView1.Columns.Add(columns[3]); // e.g. now your column 4 is placed at first position
    GridView1.Columns.Add(columns[0]); // here column 1 is placed at second position
