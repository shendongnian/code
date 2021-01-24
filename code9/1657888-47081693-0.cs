        public int PageCountWord(object Path)
        {
            // Get application object
            Microsoft.Office.Interop.Word.Application WordApplication = new Microsoft.Office.Interop.Word.Application();
            // Get document object
            object Miss = System.Reflection.Missing.Value;
            object ReadOnly = false;
            object Visible = false;
            object SaveChanges = WdSaveOptions.wdDoNotSaveChanges;
            Microsoft.Office.Interop.Word.Document Doc = WordApplication.Documents.Open(ref Path, ref Miss, ref ReadOnly, ref Miss, ref Miss, ref Miss, ref Miss, ref Miss, ref Miss, ref Miss, ref Miss, ref Visible, ref Miss, ref Miss, ref Miss, ref Miss);
            // Get pages count
            Microsoft.Office.Interop.Word.WdStatistic PagesCountStat = Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages;
            int PagesCount = Doc.ComputeStatistics(PagesCountStat, ref Miss);
            Doc.Close(SaveChanges);
            WordApplication.Quit();
            return PagesCount;
        }
