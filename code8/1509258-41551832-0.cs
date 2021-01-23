    private static int GetTablePageNumberFromTitle(string inTitle, Word.Document doc) {
      foreach (Word.Table tb in doc.Tables) {
        if (tb.Title == inTitle) {
          return tb.Range.Information[Word.WdInformation.wdActiveEndAdjustedPageNumber]; 
        }
      }
      return -1;
    }
    private static List<Word.Table> GetTablesOnPage(int targetPage, Word.Document doc) {
      List<Word.Table> tablesOnPage = new List<Word.Table>();
      int curPage = -1;
      foreach (Word.Table tb in doc.Tables) {
        curPage = tb.Range.Information[Word.WdInformation.wdActiveEndAdjustedPageNumber];
        if (curPage == targetPage) {
          tablesOnPage.Add(tb);
        }
      }
      return tablesOnPage;
    }
