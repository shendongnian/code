         private void UseObjects()
         {
             List<ExcelObjects> ListOfvarsForQuery = new List<ExcelObjects>();
    
             for (int i = 2; i < lastUsedRow + 1; i++)
             {
                 ExcelObjects obj = new ExcelObjects();
    
                 obj.CompanyVar = ws.Cells[i, 1];
                 obj.FiscalYear = ws.Cells[i, 2];
                 obj.FiscalPeriod = ws.Cells[i, 3];
                 obj.segValue1 = ws.Cells[i, 4];
                 obj.segValue2 = ws.Cells[i, 5];
                 obj.segValue3 = ws.Cells[i, 6];
                 ListOfvarsForQuery.Add(obj);
             }
    
             string SQLCode = // use the list of ExcelObjects and write a better query.
    
    
         }
     }
    
     struct ExcelObjects
     {
         public string CompanyVar;
         public string FiscalYear;
         public string FiscalPeriod;
         public string segValue1;
         public string segValue2;
         public string segValue3;
     }
