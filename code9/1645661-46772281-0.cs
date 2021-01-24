     var _separators = new[] { "-", "(", ")", "/", " ", ":", ";", ",", "."};
     protected virtual void ParseRenderInfo(TextRenderInfo currentInfo)
        {
            var resultInfo = new List<TextRenderInfo>();
            var chars = currentInfo.GetCharacterRenderInfos();
            foreach (var charRenderInfo in chars)
            {
                resultInfo.Add(charRenderInfo);
                var currentChar = charRenderInfo.GetText();
                if (_separators.Contains(currentChar))
                {
                    ProcessWord(currentInfo, resultInfo);
                    resultInfo.Clear();
                }
            }
            ProcessWord(currentInfo, resultInfo);
        }
     private void ProcessWord(TextRenderInfo charChunk, List<TextRenderInfo> wordChunks)
        {
            var firstRender = wordChunks.FirstOrDefault();
            var lastRender = wordChunks.LastOrDefault();
            if (firstRender == null || lastRender == null)
            {
                return;
            }
            var startCoords = firstRender.GetDescentLine().GetStartPoint();
            var endCoords = lastRender.GetAscentLine().GetEndPoint();
            var wordText = string.Join("", wordChunks.Select(x => x.GetText()));
            var wordLocation = new LocationTextExtractionStrategy.TextChunkLocationDefaultImp(startCoords, endCoords, charChunk.GetSingleSpaceWidth());
            _chunks.Add(new CustomTextChunk(wordText, wordLocation));
        }
