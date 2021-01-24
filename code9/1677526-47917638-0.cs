    var orderBy = new Term("MyField", string.Empty);
    using (var reader = IndexReader.Open(FSDirectory.Open(_indexPath), true))
    using (var termEnum = reader.Terms(orderBy))
    using (var stream = new FileStream("TheFile.txt", FileMode.Create, FileAccess.Write))
    using (var writer = new StreamWriter(stream))
    {
        for (var term = termEnum.Term; term != null; termEnum.Next(), term = termEnum.Term)
        {
            if (term.Field != "MyField")
            {
                break;
            }
            writer.WriteLine(term.Text);
        }
    }
