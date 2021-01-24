     StringBuilder builder = new StringBuilder();
     while (reader.Read())
     {
         if (reader.ElementType == typeof(CellValue))
         {
            builder.Append(reader.GetText() + " ");
         }
     }
