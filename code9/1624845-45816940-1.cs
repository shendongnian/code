     private int GetFirstCharIndexOfLine(ITextDocument document, int line)
        {
            string value;
            document.GetText(TextGetOptions.None, out value);
            int size = 0;            
            while (value.Length > size)
            {
                ITextRange range = document.GetRange(size, size + 1);
                size += range.Expand(TextRangeUnit.Line);
                var lineIndex = range.GetIndex(TextRangeUnit.Line);
                if (line == lineIndex)
                {
                    //start of range is first line character index
                    return range.StartPosition;
                }
                size += 1;
              
            }
            return -1;
        }
