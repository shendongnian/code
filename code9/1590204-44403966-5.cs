    if (bookLists.ContainsKey(books))
    {
      bookListBox.Items.Clear();
      selectedPictureBox.Image = Image.FromFile(bookLists[books].ImageName);
      foreach (var b in bookLists[books].Items)
      {
         bookListBox.Items.Add(b);
      }
    }
