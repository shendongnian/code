     using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
            {
                DataSet result = excelReader.AsDataSet();
                foreach (DataRow dr in result[0])
                {
                    //Do stuff
                }
            }
        }
 
