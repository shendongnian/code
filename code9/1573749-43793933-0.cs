    private class Field
    {
            public string Valor { get; set; }
    }
    
    private class Row
    {
            public List<Field> Fields { get; set; }
    
            public Row(string value)
            {
                Fields = new List<Field>();
                var fieldsString = value.Split(new char[] {'\t'});
                foreach (string f in fieldsString)
                {
                    Fields.Add(new Field {Valor = f});
                }
        }
    }
    
    public Parse()
    {
        var data = Clipboard.GetDataObject();
        var datos = (string)data.GetData(DataFormats.Text);
        var stringRows = datos.Split(new Char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
        var table = new List<Row>(stringRows.Length) ;
        foreach (string stringRow in stringRows)
        {
            table.Add( new Row(stringRow) );
        }
    }
