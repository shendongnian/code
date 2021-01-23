        class HDNData
        {
            StringBuilder builder;
    
            public void SetBuilder(StringBuilder dataBuilder)
            {
                this.builder = dataBuilder;
            }
    
            public string Data { get; set; }
            public string Hyperlink { get; set; }
            public string HexColor { get; set; }
            public override string ToString()
            {
                builder.Clear();
                bool hasHyperlink = !string.IsNullOrEmpty(Hyperlink);
                bool hasColor = !string.IsNullOrEmpty(HexColor);
                if (hasHyperlink)
                {
                    builder.Append("<a href=\"");
                    builder.Append(Hyperlink);
                    builder.Append("\">");
                }
                if(hasColor)
                {
                    builder.Append("<span style='color:");
                    builder.Append(HexColor);
                    builder.Append("'>");
                }
    
                builder.AppendLine(Data);
                if (hasHyperlink)
                    builder.Append("</a>");
                return builder.ToString();
            }
        }
        class HDNHtml
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder cellBuilder = new StringBuilder();
            private List<List<HDNData>> data = new List<List<HDNData>>();
    
            public void Add(int i, HDNData hdnData)
            {
                if(i < data.Count)
                {
                    hdnData.SetBuilder(cellBuilder);
                    data[i].Add(hdnData);
                }
                else
                {
                    if (i == data.Count)
                    {
                        data.Add(new List<HDNData>());
                        hdnData.SetBuilder(cellBuilder);
                        data[i].Add(hdnData);
                    }
                }
            }
    
            public override string ToString()
            {
                builder.Clear();
                builder.AppendLine("<html>");
                builder.AppendLine("<head></head>");
                builder.AppendLine("<body>");
                builder.AppendLine("<table>");
                builder.AppendLine("<col>");
                foreach (List<HDNData> row in data)
                {
                    builder.AppendLine("<tr>");
                    foreach (HDNData col in row)
                    {
                        builder.AppendLine("<td>");
                        builder.Append(col.ToString());
                        builder.AppendLine("</td>");
                    }
                    builder.AppendLine("</tr>");
                }
                builder.AppendLine("</table>");
                builder.AppendLine("</body>");
                builder.AppendLine("</html>");
                return builder.ToString();
            }
        }
