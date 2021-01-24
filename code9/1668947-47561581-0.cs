    using System.Linq
    
    ...
	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
        // filter movies according to selected value in first listbox
		var movies = myDic.Where(x => x.Key == listBox1.SelectedItem.ToString()).SelectMany(x => x.Value).ToList();
		listBox2.Items.Clear();
		foreach (string movie in movies)
		{
			listBox2.Items.Add(movie);
		}
	}
