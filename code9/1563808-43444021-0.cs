    Book record = new Book();
    foreach (string line in lines)
    {
           int n;
           if (!int.TryParse(line, out n))
           {
               record.Title = line;
           }
           else
           {
               record.PublicationYear = line;
               BookList.Add(record);
               record = new Book();
           }
     }
