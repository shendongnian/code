    private List<(string Topic, string ImagePath, string Title)> books;
    //In the form load code:
    books = EasyCSV.FromFile("bookData.csv").Select(b => (b[0], b[1], b[2])).ToList();
    //and finally, in the original selectindexchanged method:
    private void bookComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string topic = bookComboBox.SelectedItem.ToString();
        selectedPictureBox.Visible = true;
        var items = books.Where(b => b.Topic == topic).ToArray();
        if(items.Length > 0)
        {
            bookListBox.Items.Clear();
            selectedPictureBox.Image = Image.FromFile(items[0].ImagePath);
            bookListBox.Items.AddRange(items);
        }
    }
