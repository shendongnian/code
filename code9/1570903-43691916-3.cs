    var replacement = new Book[Books.Length + 1];
    Array.Copy(Books, 0, replacement, 0, index);
    replacement[index] = item;
    Array.Copy(Books, index, replacement, index + 1, Books.Length - index);
    Books = replacement;
