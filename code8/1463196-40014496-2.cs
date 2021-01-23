    var images = new Dictionary<char, Image>()
    {
        {'#', Properties.Resources.Image1},
        {'.', Properties.Resources.Image2},
        {'$', Properties.Resources.Image3},
        {'@', Properties.Resources.Image4},
    };
    char[][] data = new char[][]{ 
        new char[] {'#','.','#'},
        new char[] {'#','$','#'},
        new char[] {'#','@','#'},
        new char[] {'#','#','#'},
    };
    var dt = new DataTable();
    for (int i = 0; i < data.Max(x => x.Count()); i++)
        dt.Columns.Add(string.Format("C{0}", i), typeof(Image));
    data.ToList().ForEach(a => dt.Rows.Add(a.Select(x=>images[x]).ToArray()));
    this.dataGridView1.DataSource = dt;
