    public System.Data.DataTable ReadExcel(string fileName, string fileExt, strig SheetName)
        {
            string conn = string.Empty;
            System.Data.DataTable dtexcel = new System.Data.DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=YES';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
         String Query = String.Format("select * from [{0}]",SheetName);         
           // [sheet1] = [YouerSheetNameinExcelFile]
                    //OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [sheet1]", con); //here we read data from sheet1  
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter(Query, con); //here we read data from sheet1 and from specific cell range.   
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            return dtexcel;
        }
