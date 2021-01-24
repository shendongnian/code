    class LayoutTextExtractionStrategy : LocationTextExtractionStrategy
    {
        public LayoutTextExtractionStrategy(float fixedCharWidth)
        {
            this.fixedCharWidth = fixedCharWidth;
        }
        MethodInfo DumpStateMethod = typeof(LocationTextExtractionStrategy).GetMethod("DumpState", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo FilterTextChunksMethod = typeof(LocationTextExtractionStrategy).GetMethod("filterTextChunks", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo LocationalResultField = typeof(LocationTextExtractionStrategy).GetField("locationalResult", BindingFlags.NonPublic | BindingFlags.Instance);
        public override string GetResultantText(ITextChunkFilter chunkFilter)
        {
            if (DUMP_STATE)
            {
                //DumpState();
                DumpStateMethod.Invoke(this, null);
            }
            // List<TextChunk> filteredTextChunks = filterTextChunks(locationalResult, chunkFilter);
            object locationalResult = LocationalResultField.GetValue(this);
            List<TextChunk> filteredTextChunks = (List<TextChunk>)FilterTextChunksMethod.Invoke(this, new object[] { locationalResult, chunkFilter });
            filteredTextChunks.Sort();
            int startOfLinePosition = 0;
            StringBuilder sb = new StringBuilder();
            TextChunk lastChunk = null;
            foreach (TextChunk chunk in filteredTextChunks)
            {
                if (lastChunk == null)
                {
                    InsertSpaces(sb, startOfLinePosition, chunk.Location.DistParallelStart, false);
                    sb.Append(chunk.Text);
                }
                else
                {
                    if (chunk.SameLine(lastChunk))
                    {
                        // we only insert a blank space if the trailing character of the previous string wasn't a space, and the leading character of the current string isn't a space
                        if (IsChunkAtWordBoundary(chunk, lastChunk)/* && !StartsWithSpace(chunk.Text) && !EndsWithSpace(lastChunk.Text)*/)
                        {
                            //sb.Append(' ');
                            InsertSpaces(sb, startOfLinePosition, chunk.Location.DistParallelStart, !StartsWithSpace(chunk.Text) && !EndsWithSpace(lastChunk.Text));
                        }
                        sb.Append(chunk.Text);
                    }
                    else
                    {
                        sb.Append('\n');
                        startOfLinePosition = sb.Length;
                        InsertSpaces(sb, startOfLinePosition, chunk.Location.DistParallelStart, false);
                        sb.Append(chunk.Text);
                    }
                }
                lastChunk = chunk;
            }
            return sb.ToString();
        }
        private bool StartsWithSpace(String str)
        {
            if (str.Length == 0) return false;
            return str[0] == ' ';
        }
        private bool EndsWithSpace(String str)
        {
            if (str.Length == 0) return false;
            return str[str.Length - 1] == ' ';
        }
        void InsertSpaces(StringBuilder sb, int startOfLinePosition, float chunkStart, bool spaceRequired)
        {
            int indexNow = sb.Length - startOfLinePosition;
            int indexToBe = (int)((chunkStart - pageLeft) / fixedCharWidth);
            int spacesToInsert = indexToBe - indexNow;
            if (spacesToInsert < 1 && spaceRequired)
                spacesToInsert = 1;
            for (; spacesToInsert > 0; spacesToInsert--)
            {
                sb.Append(' ');
            }
        }
        public float pageLeft = 0;
        public float fixedCharWidth = 6;
    }
