    const int pageSize = 1000;
    IQueryable<MyRecord> allMyRecords = ...
    IQueryable<Page<MyRecord>> pages = allMyRecords.ToPages(1000);
    // do what you want with the pages, for example:
    foreach (Page<MyRecord> page in pages)
    {
        Console.WriteLine($"Page {page.PageNr}");
        foreach (MyRecord record in Page.Contents)
        {
           Console.WriteLine(record.ToString());
        }
    }
