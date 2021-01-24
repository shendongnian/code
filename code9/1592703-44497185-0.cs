            using (TextFieldParser parser = new TextFieldParser("yourfile"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //TODO: Process field
                    }
                }
            }
