    if (view.SelectedRowsCount == 1)
    {
        // I do what I post in my question
         }
        
            if(view.SelectedRowsCount > 1)
    {
          int[] pos = new int[view.SelectedRowsCount];
                        pos = view.GetSelectedRows();//save into an array the selected rows handle                    
                        int lastHandle = pos.Last();
                        DataTable tableAux = new DataTable();                               
                        tableAux.Columns.Add("idcentg", typeof(string));
                        tableAux.Columns.Add("idbatg", typeof(int));
                        tableAux.Columns.Add("idunig", typeof(int));
                        tableAux.Columns.Add("potCalculada", typeof(decimal));
                        tableAux.Columns.Add("potTrabajo", typeof(decimal));
                        tableAux.Columns.Add("orden", typeof(int));
                        tableAux.Columns.Add("capinsg", typeof(decimal));
        
                        for (int i = 0; i < gridView_Motores.DataRowCount; i++)
                        {
                            tableAux.Rows.Add(gridView_Motores.GetRowCellValue(i,"idcentg"), gridView_Motores.GetRowCellValue(i, "idbatg"), 
                                              gridView_Motores.GetRowCellValue(i, "idunig"), gridView_Motores.GetRowCellValue(i, "potCalculada"),
                                              gridView_Motores.GetRowCellValue(i, "potTrabajo"), gridView_Motores.GetRowCellValue(i, "orden"),
                                              gridView_Motores.GetRowCellValue(i, "capinsg"));
                        }              
        
                        int tag = 1;
                        int cont = 1;
                        for (int i = 0; i < pos.Length; i++)
                        {
                            if (tag == 1)
                            {
                                DataRow selectedRow = tableAux.Rows[pos[i]];
                                DataRow newRow = tableAux.NewRow();
                                newRow.ItemArray = selectedRow.ItemArray;
                                tableAux.Rows.Remove(selectedRow);
                                tableAux.Rows.InsertAt(newRow, lastHandle + 1);
                            }
                            else
                            {
                                DataRow selectedRow = tableAux.Rows[pos[i] - cont];
                                DataRow newRow = tableAux.NewRow();
                                newRow.ItemArray = selectedRow.ItemArray;
                                tableAux.Rows.Remove(selectedRow);
                                tableAux.Rows.InsertAt(newRow, lastHandle + 1);
                                cont++;
                            }
                            tag++;                                 
                        }
        
                        int orden = 1;
                        foreach (DataRow row in tableAux.Rows)
                        {
                            row["orden"] = orden;
                            orden++;
                        }                 
        
                        grid_OrdenMotores.DataSource = null;
                        grid_OrdenMotores.DataSource = tableAux;
        }
