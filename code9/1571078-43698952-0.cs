        //sample text : "aaaa bbbb @cccc dddd @eee fff g"
        public string GetProperText(string text)
        { 
            if (text.Contains('@'))
            {
                int index = text.IndexOf('@');            //Index of first occuring '@'
                var indexLast = text.IndexOf(' ',index);  //Index of first ' ' after '@'
                var oldName = text.Substring(index, indexLast);     //Old Name
                string processedText = text.Substring(0, index + indexLast).Replace(oldName, "New");    //String with new name
                string restText = text.Substring(indexLast);   //Rest Text
                if (text.Contains('@'))
                {
                    //Here the outcome of the function is pasted on the allready processed text part.
                    text = processedText + GetProperText(restText);
                }
                return text;
            }
            else
            {
                return text;
            }
        }
