            const int hCol = 8;
            const int iCol = 9;
            //start at 1 as there are column headings
            for (int i = 1; i < sourceSheet.UsedRange.Rows.Count; i++)
            {
                if ((sourceSheet.cells[i, iCol].value??"").ToString()!="" && 
                    (sourceSheet.cells[i, hCol].value??"").ToString()=="")
                {
                    sourceSheet.cells[i, hCol].value = sourceSheet.cells[i, iCol].value;
                    sourceSheet.cells[i, iCol].value = "";
                }
            } 
