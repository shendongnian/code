        var xml = new XElement(table.TableName, table.Rows.Cast<DataRow>()
            .GroupBy(row => (string)row[0])
            .Select(g =>
                new XElement(table.Columns[0].ColumnName,
                    new XElement("label", (string)g.First()[0]),
                    g.GroupBy(row => (string)row[1])
                     .Select(g1 =>
                        new XElement(table.Columns[1].ColumnName,
                            new XElement("label", (string)g1.First()[1]),
                            new XElement(table.Columns[2].ColumnName,
                                g1.Select(row =>
                                    new XElement("label", (string)row[2])
                                )
                            )
                        )
                    )
                )
            )
        ).ToString();
