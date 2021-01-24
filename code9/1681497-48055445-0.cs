            if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
            {                
                DataTable distinctDataTable = dsResult.Tables[0].AsEnumerable()
                    .GroupBy(row => row.Field<string>("MonthName"))
                    .Select(group => group.First()).CopyToDataTable()
                foreach (DataRow dtRow in distinctDataTable.Rows)
                {
                    dgvReport.Rows.Add(
                       dtRow["MonthName"].ToString(),
                       dtRow["new_card_qty"].ToString(),
                       dtRow["new_card_total"].ToString(),
                       dtRow["Top_Up_Value"].ToString()
                    );
                }
            }
