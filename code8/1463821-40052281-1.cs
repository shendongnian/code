            Array links = wbOut.LinkSources(Microsoft.Office.Interop.Excel.XlLink.xlExcelLinks) as Array;
            if (links != null)
            {
                for (int i = 1; i <= links.Length; i++)
                {
                    wbOut.ChangeLink(@"c:\temp\book1.xls", @"c:\temp\book2.xls", 
                           XlLinkType.xlLinkTypeExcelLinks);
                }
            }
