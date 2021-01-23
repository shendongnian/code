    //DISCLAIMER; typed in my cell phone, not tested. Sure it has bugs but you should get the idea.
    public string get_element(int index)
    {
         var buffer = new StringBuilder();
         var counter = -1;
         using (var enumerator = text_line.GetEnumerator())
         {
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
