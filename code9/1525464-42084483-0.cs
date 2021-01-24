     string[] fields = new string[] { "Product Name", "Cost Price", "Sold Quantity", "Sales Amount", "Net Amount", " Profit", "Sale Date" };
 
        StringBuilder sb = new StringBuilder();
        string fieldSeperator = "\t|";
        foreach (String h in fields)
            sb.Append(h + fieldSeperator);
        sb.Append(Environment.NewLine);
        while (reader.Read())
        {
            foreach(string fieldName in fields)
            {
                switch (fieldName)
                {
                    case "Product Name":    sb.Append(reader[0].PadRight(fieldName.Length));
                        break;
                    case "Cost Price":      sb.Append(reader[1].PadRight(fieldName.Length));
                        break;
                    case "Sold Quantity":   sb.Append(reader[2].PadRight(fieldName.Length));
                        break;
                    case "Sales Amount":    sb.Append(reader[3].PadRight(fieldName.Length));
                        break;
                    case "Net Amount":      sb.Append(reader[4].PadRight(fieldName.Length));
                        break;
                    case " Profit":          sb.Append(reader[5].PadRight(fieldName.Length));
                        break;
                    case "Sale Date":       sb.Append(reader[6].PadRight(fieldName.Length));
                        break;
                }                    
                sb.Append(fieldSeperator);                    
            }
            sb.Append(Environment.NewLine);
        }
        result = sb.ToString();
