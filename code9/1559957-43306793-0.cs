     public class ExcelService : IExcelService
    {
        public List<CustomExcelData> GetExcelData()
        {
            List<CustomExcelData> excelDataList = new List<CustomExcelData>();
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (opn.ShowDialog() == DialogResult.Cancel)
                return null;
            FileStream strm = new FileStream(opn.FileName, FileMode.Open);
            IExcelDataReader excldr = ExcelReaderFactory.CreateOpenXmlReader(strm);
            DataSet rslt = excldr.AsDataSet();
            DataTable dt = rslt.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    excelDataList.Add(new CustomExcelData(row));
                }
            }
            return excelDataList;
        }
    }
