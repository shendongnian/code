    using (var parser = new TextFieldParser(new StringReader(s))){
         parser.TextFieldType = FieldType.FixedWidth;
         parser.SetFieldWidths(2,1,4 /*etc*/);
         while (!parser.EndOfData)
         {
             var data = parser.ReadFields(); //string[]
         }
    }
