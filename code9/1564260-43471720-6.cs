    public string ExcelReader(string excelFilePath)
        {
            StringBuilder resultText = new StringBuilder();
            //string excelFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test.xls");
            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(excelFilePath);
            Worksheet excelSheet = wb.ActiveSheet;
            //Read the first cell
            Range cell = excelSheet.Cells[1, 1];
            //Check if one bold or italic WORD.
            bool IfStop = false;
            //Check if character is the start of bold or italic character.
            bool ifFirstSpecialCharacter = true;
            //Initialize a empty tag
            string tag = "";
            //Check if it is the last index
            bool isLastIndex = false;
            for (int index = 1; index <= cell.Text.ToString().Length; index++)
            {
                //Check if the current character is bold or italic
                bool IfSpecialType = false;
                //cell here is a Range object
                Characters ch = cell.get_Characters(index, 1);
                XlUnderlineStyle temp = (XlUnderlineStyle)ch.Font.Underline;
                bool underline = false;
                if (temp == XlUnderlineStyle.xlUnderlineStyleSingle)
                    underline = true;
                bool bold = (bool)ch.Font.Bold;
                bool italic = (bool)ch.Font.Italic;
                if (underline)
                {
                    if (tag != "" && tag != "<u>")
                    {
                        resultText.Append(tag.Insert(1, "/"));
                        ifFirstSpecialCharacter = true;
                        IfStop = true;
                    }
                    tag = "<u>";
                    IfSpecialType = true;
                }
                if (bold)
                {
                    if (tag != "" && tag != "<b>")
                    {
                        resultText.Append(tag.Insert(1, "/"));
                        ifFirstSpecialCharacter = true;
                        IfStop = true;
                    }
                    tag = "<b>";
                    IfSpecialType = true;
                }
                if (italic)
                {
                    if (tag != "" && tag != "<i>")
                    {
                        resultText.Append(tag.Insert(1, "/"));
                        ifFirstSpecialCharacter = true;
                        IfStop = true;
                    }
                    tag = "<i>";
                    IfSpecialType = true;
                }
                if (index == cell.Text.ToString().Length)
                    isLastIndex = true;
                DetectSpecialCharracterByType(isLastIndex, resultText, ref tag, IfSpecialType, ref IfStop, ref ifFirstSpecialCharacter, ch);
            }
            wb.Close();
            return resultText.ToString();
        }
