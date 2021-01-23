            IExcelDataReader reader = null;
            string FilePath = "PathToExcelFile";
            //Load file into a stream
            FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
            //Must check file extension to adjust the reader to the excel file type
            if (Path.GetExtension(FilePath).Equals(".xls"))
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            else if (Path.GetExtension(FilePath).Equals(".xlsx"))
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            if (reader != null)
            {
                //Fill DataSet
                DataSet content = reader.AsDataSet();
                //Read....
            }
