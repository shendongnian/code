        Word.Application oWord;
        Word._Document oDoc;
        oWord = new Word.Application();
        oWord.Visible = false;
        oDoc = oWord.Documents.Open(strWorkingPath, ReadOnly: true);
        //===================Excute===================
        /*Word 2013*/
        oWord.ActiveWindow.View.ReadingLayout = false;
        // Get pages count
        Word.WdStatistic PagesCountStat = Word.WdStatistic.wdStatisticPages;
        int nTotalPage = oDoc.ComputeStatistics(PagesCountStat);
        int nEndOfTheDoc = oDoc.Paragraphs.Last.Range.Sentences.First.End;
        int nStart = 0;
        int nEnd = nEndOfTheDoc;
        List<int> lstPage = new List<int>();
        int color = 696969;//The color you can get by read the Font.Color of the Range in Debug view
        Word.Range findRange;
        object What = Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage;
        object Which = Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToAbsolute;
        object nCrtPage;
        object nNextPage;
        bool bPageIsIn = false;
        /*Loop the pages*/
        for (int i = 1; i <= nTotalPage; i++)
        {
            /*Get the start and end position of the current page*/
            nCrtPage = i;
            nNextPage = i + 1;
            nStart = oWord.Selection.GoTo(ref What,
               ref Which, ref nCrtPage).Start;
            nEnd = oWord.Selection.GoTo(ref What,
               ref Which, ref nNextPage).End;
            /*The last page: nStart will equal nEnd*/
            if(nStart == nEnd)
            {
                /*Set nEnd for the last page*/
                nEnd = nEndOfTheDoc;
            }
            /*Set default for Count page trigger*/
            bPageIsIn = false;
            /*Set the find range is the current page range*/
            findRange = oDoc.Range(nStart, nEnd);
            /*Set up find condition*/
            findRange.Find.Font.Color = (Word.WdColor)color;
            findRange.Find.Format = true;
            findRange.Find.Text = "^?";
            do
            {
                /*Loop find next*/
                findRange.Find.Execute();
                /*If found*/
                if (findRange.Find.Found)
                {
                    /*If found data is still in the page*/
                    if (findRange.End <= nEnd)
                    {
                        /*If found data is visible by human eyes*/
                        if (!string.IsNullOrWhiteSpace(findRange.Text))
                        {
                            /*Ok, count this page*/
                            bPageIsIn = true;
                            break;/*no need to find anymore for this page*/
                        }
                    }
                }
                else
                    break;/*no need to find anymore for this page*/
            }while (findRange.End < nEnd);/*Make sure it is in that page only*/
            if (bPageIsIn)
                lstPage.Add(i);
        }
        //===================Close===================
        oDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
        ((Word._Application)oWord).Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
        foreach (var item in lstPage)
        {
            builder.AppendLine(item.ToString());//Do anything you like with the list page
        }
