    var book = new Book();
    book.Name = nameTextBox.Text;
    book.Author = authorTextBox.Text;
    book.ISBN = isbnTextBox.Text;
    book.Price = int.Parse(priceTextBox.Text);
    books.Add(book);
