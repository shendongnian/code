    DataTable dtExcelData = new DataTable();
     //Fill dtExcelData and pass as parameter
     ParametersCollection param = new ParametersCollection();
     param.Add(CreateParameter("@DataImported", dtExcelData));
     ExecuteDataSet("spImportData", CommandType.StoredProcedure, param);
