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
    
                    bool bold = (bool)ch.Font.Bold;
                    bool italic = (bool)ch.Font.Italic;
    
                    if (bold) { tag = "<b>"; IfSpecialType = true; }
                    if (italic) { tag = "<i>"; IfSpecialType = true; }
                    if (index == cell.Text.ToString().Length)
                        isLastIndex = true;
                    DetectSpecialCharracterByType(isLastIndex, resultText, tag, IfSpecialType, ref IfStop, ref ifFirstSpecialCharacter, ch);
                }
                wb.Close();
                return resultText.ToString();
            }
