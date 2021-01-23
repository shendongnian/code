    StringBuiler buffer = new StringBuilder();
    public string get_element(int index)
    {
         var counter = -1;
         
         using (var enumerator = text_line.GetEnumerator())
         {
             buffer.Clear();
             while (enumerator.MoveNext())
             {
                 if (enumerator.Current == x12_reader.element_delimiter)
                 {
                     counter++;
                 }
                 else if (counter == index)
                 {
                     buffer.Append(enumerator.Current);
                 }
                 else if (counter > index)
                     break;
            }
         }
         return buffer.ToString();
    }
