    string books = null;
    books = bookComboBox.SelectedItem.ToString();
    selectedPictureBox.Visible = true;
    
    for (int i = 0; i < categories.Count; i++) {
        if (books == categories[i].Name) {
            bookListBox.Items.Clear();
            selectedPictureBox.Image = Image.FromFile(categories[i].ImagePath);
            for (int j = 0; j < categories[i].Items.Count; j++) {
                 bookListBox.Items.Add(categories[i].Items[j]);
            }        
        }
    }
