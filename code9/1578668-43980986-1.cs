    DT = DT.AsEnumerable()
           .Select(
                    row =>
                    { 
                      row["ComputedCol"] = (int)DT.Compute(row["FormulaCol"].ToString()
                                 .Replace("x", row["x"].ToString())
                                 .Replace("y", row["y"].ToString()), "");
                      return row;
                     }
                   ).CopyToDataTable<DataRow>();
