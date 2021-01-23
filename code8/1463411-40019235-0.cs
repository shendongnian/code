    foreach (Book b in fak[1].GetBookList())
    {
      if (a.Pav == b.Pav)
      {
        RareBooks.Remove(a);
        RareBooks.Remove(b);
      }
    }
