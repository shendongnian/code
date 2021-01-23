    var images = new Dictionary<char, Image>()
    {
        {'#', Properties.Resources.Image1},
        {'.', Properties.Resources.Image2},
        {'$', Properties.Resources.Image3},
        {'@', Properties.Resources.Image4},
    };
    var data = new List<string>() { "#.#", "#$#", "#@#", "###" };
    var list = data.Select(x => new
                           {
                               A = images[x[0]],
                               B = images[x[1]],
                               C = images[x[2]]
                           }).ToList();
    this.dataGridView1.DataSource = list;
