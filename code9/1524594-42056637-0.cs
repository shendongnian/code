    using (TextFieldParser sr = new TextFieldParser(datapath)
            {
                Delimiters = new string[1] { "," },
                HasFieldsEnclosedInQuotes = true;
            })
    {
         string[] values = sr.ReadFields();
         while (values != null)
         {
          // ....
          values = sr.ReadFields();
         }
    }
