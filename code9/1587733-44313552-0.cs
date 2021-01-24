    using (TextReader textReader = new StreamReader(filePath))
    {
        using (var csvReader = new CsvReader(textReader))
        {
            var headers = csvReader.FieldHeaders;
            for (int rowIndex = 0; csvReader.Read(); rowIndex++)
            {
                var dataRow = dataTable.NewRow();
                for (int chosenColumnIndex = 0; chosenColumnIndex < columns.Count(); chosenColumnIndex++)
                {
                    for (int headerIndex = 0; headerIndex < headers.Length; headerIndex++)
                    {
                        if (headers[headerIndex] == columns[chosenColumnIndex])
                        {
                            dataRow[chosenColumnIndex] = csvReader.GetField<string>(headerIndex);
                        }
                    }
                }
                dataTable.Rows.InsertAt(dataRow, rowIndex);
            }
        }
    }
