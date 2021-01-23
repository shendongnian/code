    string mm = wbOut.Name.ToString();
            Array links = wbOut.LinkSources(Microsoft.Office.Interop.Excel.XlLink.xlExcelLinks) as Array;
            if (links != null)
            {
                for (int i = 1; i <= links.Length; i++)
                {
                    wbOut.ChangeLink("book1.xls", mm, 
                           XlLinkType.xlLinkTypeExcelLinks);
                }
            }
