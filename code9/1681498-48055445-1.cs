            if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
            {
                var distinctDataTable = dsResult.Tables[0].AsEnumerable()
                    .GroupBy(row => row.Field<string>("MonthName"))
                    .Select(group => new
                    {
                        MonthName = group.Key,
                        new_card_qty = group.Sum(e => Convert.ToInt32(e["new_card_qty"])),
                        new_card_total = group.Sum(e => Convert.ToDouble(e["new_card_total"])),
                        Top_Up_Value = group.Sum(e => Convert.ToDouble(e["Top_Up_Value"])),
                    });
                foreach (var dtRow in distinctDataTable)
                {
                    dgvReport.Rows.Add(
                       dtRow.MonthName,
                       dtRow.new_card_qty,
                       dtRow.new_card_total,
                       dtRow.Top_Up_Value,
                    );
                }
            }
