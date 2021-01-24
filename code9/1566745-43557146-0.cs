    Dictionary<string, string> dict = (from cell in sheet.Cells["A1:B34"]
                                     where cell.Start.Column == 1 && cell.Value != null
                                     select sheet.Cells[cell.Start.Row, cell.Start.Column, cell.Start.Row, 2].Value)
                                                            .Cast<object[,]>()
                                                            .GroupBy(k => Convert.ToString(k[0,0]))
                                                            .Select(k =>  k.First())
                                                            .ToDictionary(k => Convert.ToString(k[0, 0]), v => Convert.ToString(v[0, 1]))
