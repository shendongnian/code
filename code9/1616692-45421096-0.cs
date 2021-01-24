        public static XSSFWorkbook ReadExcelFile(string strFilePath)
        {
            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(strFilePath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }
            return hssfwb;
        }
        private void OpenExcelFile_Click(object sender, EventArgs e)
        {
            var dt = ReadExcelFile(@"C:\\Users\\emmanuel.adefuye\\Documents\\ExcelTestFile.xlsx");
        }
