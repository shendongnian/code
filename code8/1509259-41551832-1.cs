      Console.WriteLine("--------------");
      Console.WriteLine("Get page table named 'table3' is on...");
      int pageNum = GetTablePageNumberFromTitle("table3", doc);
      Console.WriteLine("'table3 is on page: " + pageNum);
      Console.WriteLine("--------------");
      Console.WriteLine("Get page table named 'table2' is on... It starts on page 2 and ends on page 3");
      pageNum = GetTablePageNumberFromTitle("table2", doc);
      Console.WriteLine("'table2 is on page: " + pageNum);
      Console.WriteLine("--------------");
      Console.WriteLine("Get tables on page 4");
      List<Word.Table> allTables = GetTablesOnPage(4, doc);
      foreach (Word.Table tb in allTables) {
        Console.WriteLine(tb.Title + " is on page " + 4);
      }
      Console.WriteLine("--------------");
      Console.WriteLine("Get tables on page 5");
      allTables = GetTablesOnPage(5, doc);
      foreach (Word.Table tb in allTables) {
        Console.WriteLine(tb.Title + " is on page " + 5);
      }
