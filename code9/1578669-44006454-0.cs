     for (int i = 0; i < DT.Rows.Count; i++){
     
    string formula=DT.Rows[i]["FormulaCol"].ToString()
     for (int j = 0; j < DT.Columns.Count; j++){
     furmula=formula.Replace(DT.Columns[j].Name ,DT.Rows[i][j].ToString())
     }
   
    DT.Rows[i]["ComputedCol"] =(int)DT.Compute(formula , "")
    }
