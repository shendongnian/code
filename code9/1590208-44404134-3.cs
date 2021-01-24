    private Dictionary<string, (string image, List<string> books)> books = new Dictionary<string, (string image, List<string> books)>
    {
        { "Programming", ("programming.png", new List<string> { "Visual Basic", "Java", "C#"} ) },
        { "Networking", ("networking.png", new List<string> {"LAN Networks", "Windows Networking", "More About Networking"}) },
        { "Web", ("html.png", new List<string> {"Web Programming", "Javascript", "ASP"}) }
    };
    private void bookComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // sets books to the clicked item
        string book = bookComboBox.SelectedItem.ToString();
        selectedPictureBox.Visible = true;
        if (books.Keys.Contains(book))
        {
            bookListBox.Items.Clear();
            selectedPictureBox.Image = Image.FromFile(books[book].image);
            foreach(var b in books[book].books)
            {
               bookListBox.Items.Add(b);
            }
        }
    }
