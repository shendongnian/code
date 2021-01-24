    private Dictionary<string, BookGroup> books = new Dictionary<string, BookGroup>
    {
        { "Programming", new BookGroup("programming.png", "Visual Basic", "Java", "C#")},
        { "Networking", new BookGroup("networking.png","LAN Networks", "Windows Networking", "More About Networking") },
        { "Web", new BookGroup("html.png", "Web Programming", "Javascript", "ASP") }
    };
    private void bookComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // sets books to the clicked item
        string book = bookComboBox.SelectedItem.ToString();
        selectedPictureBox.Visible = true;
        if (books.Keys.Contains(book))
        {
            bookListBox.Items.Clear();
            BookGroup bg = books[book];
            selectedPictureBox.Image = Image.FromFile(bg.ImagePath);
            foreach(var b in bg.Books)
            {
               bookListBox.Items.Add(b);
            }
        }
    }
