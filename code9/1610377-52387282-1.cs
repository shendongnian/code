        private void sBAdd_Click(object sender, EventArgs e)
        {
            
                DataTable dt = new DataTable();
                dt.Columns.Add("MonthlyActualPeriod1", typeof(System.Int32));
                dt.Columns.Add("MonthlyActualPeriod2", typeof(System.Int32));
                dt.Columns.Add("YearlyActualYear1", typeof(System.Int32));
                dt.Columns.Add("YearlyActualYear2", typeof(System.Int32));
                dt.Columns.Add("MonthlyBudgetPeriod1", typeof(System.Int32));
                dt.Columns.Add("MonthlyBudgetPeriod2", typeof(System.Int32));
                dt.Columns.Add("YearlyBudgetYear1", typeof(System.Int32));
                dt.Columns.Add("YearlyBudgetYear2", typeof(System.Int32));
                dt.Columns.Add("MonthlyActualCurrentPeriod", typeof(System.Int32));
                dt.Columns.Add("YearlyActualCurrentyear", typeof(System.Int32));
                dt.Columns.Add("YearlyActualPrioryear", typeof(System.Int32));
                dt.Columns.Add("MonthlyBudgetCurrentPeriod", typeof(System.Int32));
                dt.Columns.Add("YearlyBudgetCurrentyear", typeof(System.Int32));
                dt.Columns.Add("YearlyBudgetPrioryear", typeof(System.Int32));                
                for (int i = 1; i < 61; i++)
                {
                    dt.Columns.Add("MonthlyActualCurrentPeriod-" + i, typeof(System.Int32));                
                    dt.Columns.Add("MonthlyBudgetCurrentPeriod-" + i, typeof(System.Int32));
                }
                int j = dt.Columns.Count;
                DataRow row;
                foreach (DataColumn cl in dt.Columns)
                {
                    row = dt.NewRow();
                   for (int i = 0; i < j; i++)
                    {
                        row[i] = 1;
                    }
                    dt.Rows.Add(row);
                }             
                               
                this.gcCalcFields.DataSource = dt;
                       
            // Create an unbound column.
            GridColumn unbColumn = gridView1.Columns.AddField("CalcFields");
            unbColumn.VisibleIndex = gridView1.Columns.Count;
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            ColumnFilterMode prev = unbColumn.FilterMode;
            unbColumn.FilterMode = ColumnFilterMode.Value;
            gridView1.ShowUnboundExpressionEditor(unbColumn);
            unbColumn.FilterMode = prev;
            string Calculation = "";
            Calculation = unbColumn.UnboundExpression;
            LBCCalcFieldsActual.Items.Add(Calculation);
            
            gridView1.Columns.Remove(gridView1.Columns["CalcFields"]);
        }
