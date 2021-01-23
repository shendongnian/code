        static void Main(string[] args)
        {
            IExcelDataReader reader = null;
            string FilePath = "PathToExcelFile";
            //Load file into a stream
            FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
            //Must check file extension to adjust the reader to the excel file type
            if (System.IO.Path.GetExtension(FilePath).Equals(".xls"))
            {
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else if (System.IO.Path.GetExtension(FilePath).Equals(".xlsx"))
            {
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            if (reader != null)
            {
                //Fill DataSet
                System.Data.DataSet result = reader.AsDataSet();
                try
                {
                    //Loop through rows for the desired worksheet
                    //In this case I use the table index "0" to pick the first worksheet in the workbook
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        string FirstColumn = row[0].ToString();
                    }
                }
                catch
                {
                }
            }
        }
