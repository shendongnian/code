    private void addGridStyle(ref DataGrid dg, DataTable cem)
        {
            DataGridTableStyle dtStyle = new DataGridTableStyle();
            dtStyle.MappingName = cem.TableName;
    
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ColumnStyle myStyle = new ColumnStyle(i);
                myStyle.MappingName = dt.Columns[i].ColumnName;
    
                if (dt.Columns[i].ColumnName == "urunadi" || dt.Columns[i].ColumnName == "urunkodu" || dt.Columns[i].ColumnName == "toplanan_miktar" || dt.Columns[i].ColumnName == "miktar")
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
    
                if (dt.Columns[i].ColumnName == "urunadi" || dt.Columns[i].ColumnName == "urunkodu" || dt.Columns[i].ColumnName == "toplanan_miktar" || dt.Columns[i].ColumnName == "miktar")
                    myStyle.CheckRowContains += new CheckCellEventHandler(myStyle_CheckRowContains);
    
                dtStyle.GridColumnStyles.Add(myStyle);
            }
            dg.TableStyles.Add(dtStyle);
            dg.ColumnHeadersVisible = true;
        }
    
        public void myStyle_isEven(object sender, DataGridEnableEventArgs e)
        {
            try
            {
                if ((int)toplamaGrid[e.Row, 2] == (int)toplamaGrid[e.Row, 3])
                    e.MeetsCriteria = true;
                else
                    e.MeetsCriteria = false;
            }
            catch (Exception ex)
            {
                e.MeetsCriteria = false;
            }
        }
    
        public void myStyle_CheckRowContains(object sender, DataGridEnableEventArgs e)
        {
            try
            {
                if (((int)toplamaGrid[e.Row, 2] > (int)toplamaGrid[e.Row, 3]) && (int)toplamaGrid[e.Row, 3] > 0)
                    e.MeetsCriteria = true;
                else
                    e.MeetsCriteria = false;
            }
            catch (Exception ex)
            {
                e.MeetsCriteria = false;
            }
        }
