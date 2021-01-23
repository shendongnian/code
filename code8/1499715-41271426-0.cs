     private void DocReader(string fileLocation,string headingText, string headingStyle)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = fileLocation;
            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            string totaltext = "";
            int ind = 0;
            bool flag = false;
           
            int paraCount = docs.Paragraphs.Count;
            for (int i = 1; i < paraCount; i++)
            {
                Microsoft.Office.Interop.Word.Style style = docs.Paragraphs[i].get_Style() as Microsoft.Office.Interop.Word.Style;
                if (style != null && style.NameLocal.Equals(headingStyle))
                {
                    flag = false;
                    if (docs.Paragraphs[i].Range.Text.ToString().TrimEnd('\r').ToUpper() == headingText.ToUpper())
                    {
                        ind++;
                        flag = true;
                    }
                }
                if (flag && ind>=1)
                    totaltext += " \r\n " + docs.Paragraphs[i].Range.Text.ToString();
            }
            if (totaltext == "") { totaltext = "No such data found!"; }
            richTextBox1.Text = totaltext;
            docs.Close();
            word.Quit();  }
