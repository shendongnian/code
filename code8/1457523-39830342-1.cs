    if (ImportExcelDT.Rows.Count > 0)
    {
        ExportExcelDT = ImportExcelDT.Clone();
        for (int i = 0; i < ImportExcelDT.Rows.Count; i++)
        {
    
            string EmpCod = ImportExcelDT.Rows[i]["Employee Code"].ToString();
            bool isEmpCod = Regex.IsMatch(EmpCod, @"^[a-zA-Z0-9/-]+$");
    
            //Here i am checking condition if its false
                if (!isEmpCod)
                {
                    count++;
                    //Now i want to copy and delete selected row in another data table 
                    for (int j = 0; j < ExportExcelDT.Columns.Count; j++)
                    {
                        ExportExcelDT.ImportRow(ImportExcelDT.Rows[i]);
                        ImportExcelDT.Rows[i].Delete();
                    }
                }
            else
            {
    
            }
        }
    }
