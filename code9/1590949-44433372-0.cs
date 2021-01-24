            object What = Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage;
            object Which = Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToAbsolute;
            object Miss = System.Reflection.Missing.Value;
            word.Pages pages = doc.ActiveWindow.ActivePane.Pages;
            for (int i = 0; i < pages.Count; i++)
            {
              
                if (i == pageNumber)
                {
                    doc.Application.Selection.GoTo(ref What, ref Which, pageNumber, ref Miss);
                }
            }
        }
