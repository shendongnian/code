    private class myLocationTextExtractionStrategy : LocationTextExtractionStrategy
    {
      public float UndercontentCharacterSpacing { get; set; }
      public float UndercontentHorizontalScaling { get; set; }
      private SortedList<string, DocumentFont> ThisPdfDocFonts = new SortedList<string, DocumentFont>();
      private List<TextChunk> locationalResult = new List<TextChunk>();
      private bool StartsWithSpace(String inText)
      {
        if (string.IsNullOrEmpty(inText))
        {
          return false;
        }
        if (inText.StartsWith(" "))
        {
          return true;
        }
        return false;
      }
      private bool EndsWithSpace(String inText)
      {
        if (string.IsNullOrEmpty(inText))
        {
          return false;
        }
        if (inText.EndsWith(" "))
        {
          return true;
        }
        return false;
      }
      public override string GetResultantText()
      {
        locationalResult.Sort();
        StringBuilder sb = new StringBuilder();
        TextChunk lastChunk = null;
        foreach (var chunk in locationalResult)
        {
          if (lastChunk == null)
          {
            sb.Append(chunk.text);
          }
          else
          {
            if (chunk.SameLine(lastChunk))
            {
              float dist = chunk.DistanceFromEndOf(lastChunk);
              if (dist < -chunk.charSpaceWidth)
              {
                sb.Append(" ");
              }
              else if (dist > chunk.charSpaceWidth / 2.0F && !StartsWithSpace(chunk.text) && !EndsWithSpace(lastChunk.text))
              {
                sb.Append(" ");
              }
              sb.Append(chunk.text);
            }
            else
            {
              sb.Append("\n");
              sb.Append(chunk.text);
            }
          }
          lastChunk = chunk;
        }
        return sb.ToString();
      }
      public List<iTextSharp.text.Rectangle> GetTextLocations(string pSearchString, System.StringComparison pStrComp)
      {
        List<iTextSharp.text.Rectangle> FoundMatches = new List<iTextSharp.text.Rectangle>();
        StringBuilder sb = new StringBuilder();
        List<TextChunk> ThisLineChunks = new List<TextChunk>();
        bool bStart = false;
        bool bEnd = false;
        TextChunk FirstChunk = null;
        TextChunk LastChunk = null;
        string sTextInUsedChunks = null;
        foreach (var chunk in locationalResult)
        {
          if (ThisLineChunks.Count > 0 && !chunk.SameLine(ThisLineChunks.Last()))
          {
            if (sb.ToString().IndexOf(pSearchString, pStrComp) > -1)
            {
              string sLine = sb.ToString();
              int iCount = 0;
              int lPos = 0;
              lPos = sLine.IndexOf(pSearchString, 0, pStrComp);
              while (lPos > -1)
              {
                iCount++;
                if (lPos + pSearchString.Length > sLine.Length)
                {
                  break;
                }
                else
                {
                  lPos = lPos + pSearchString.Length;
                }
                lPos = sLine.IndexOf(pSearchString, lPos, pStrComp);
              }
              int curPos = 0;
              for (int i = 1; i <= iCount; i++)
              {
                string sCurrentText;
                int iFromChar;
                int iToChar;
                iFromChar = sLine.IndexOf(pSearchString, curPos, pStrComp);
                curPos = iFromChar;
                iToChar = iFromChar + pSearchString.Length - 1;
                sCurrentText = null;
                sTextInUsedChunks = null;
                FirstChunk = null;
                LastChunk = null;
                foreach (var chk in ThisLineChunks)
                {
                  sCurrentText = sCurrentText + chk.text;
                  if (!bStart && sCurrentText.Length - 1 >= iFromChar)
                  {
                    FirstChunk = chk;
                    bStart = true;
                  }
                  if (bStart && !bEnd)
                  {
                    sTextInUsedChunks = sTextInUsedChunks + chk.text;
                  }
                  if (!bEnd && sCurrentText.Length - 1 >= iToChar)
                  {
                    LastChunk = chk;
                    bEnd = true;
                  }
                  if (bStart && bEnd)
                  {
                    FoundMatches.Add(GetRectangleFromText(FirstChunk, LastChunk, pSearchString, sTextInUsedChunks, iFromChar, iToChar, pStrComp));
                    curPos = curPos + pSearchString.Length;
                    bStart = false;
                    bEnd = false;
                    break;
                  }
                }
              }
            }
            sb.Clear();
            ThisLineChunks.Clear();
          }
          ThisLineChunks.Add(chunk);
          sb.Append(chunk.text);
        }
        return FoundMatches;
      }
      private iTextSharp.text.Rectangle GetRectangleFromText(TextChunk FirstChunk, TextChunk LastChunk, string pSearchString,
        string sTextinChunks, int iFromChar, int iToChar, System.StringComparison pStrComp)
      {
        float LineRealWidth = LastChunk.PosRight - FirstChunk.PosLeft;
        float LineTextWidth = GetStringWidth(sTextinChunks, LastChunk.curFontSize,
                                                     LastChunk.charSpaceWidth,
                                                     ThisPdfDocFonts.ElementAt(LastChunk.FontIndex).Value);
        float TransformationValue = LineRealWidth / LineTextWidth;
        int iStart = sTextinChunks.IndexOf(pSearchString, pStrComp);
        int iEnd = iStart + pSearchString.Length - 1;
        string sLeft;
        if (iStart == 0)
        {
          sLeft = null;
        }
        else
        {
          sLeft = sTextinChunks.Substring(0, iStart);
        }
        string sRight;
        if (iEnd == sTextinChunks.Length - 1)
        {
          sRight = null;
        }
        else
        {
          sRight = sTextinChunks.Substring(iEnd + 1, sTextinChunks.Length - iEnd - 1);
        }
        float LeftWidth = 0;
        if (iStart > 0)
        {
          LeftWidth = GetStringWidth(sLeft, LastChunk.curFontSize,
                                            LastChunk.charSpaceWidth,
                                            ThisPdfDocFonts.Values.ElementAt(LastChunk.FontIndex));
          LeftWidth = LeftWidth * TransformationValue;
        }
        float RightWidth = 0;
        if (iEnd < sTextinChunks.Length - 1)
        {
          RightWidth = GetStringWidth(sRight, LastChunk.curFontSize,
                                              LastChunk.charSpaceWidth,
                                              ThisPdfDocFonts.Values.ElementAt(LastChunk.FontIndex));
          RightWidth = RightWidth * TransformationValue;
        }
        float LeftOffset = FirstChunk.distParallelStart + LeftWidth;
        float RightOffset = LastChunk.distParallelEnd - RightWidth;
        return new iTextSharp.text.Rectangle(LeftOffset, FirstChunk.PosBottom, RightOffset, FirstChunk.PosTop);
      }
      private float GetStringWidth(string str, float curFontSize, float pSingleSpaceWidth, DocumentFont pFont)
      {
        char[] chars = str.ToCharArray();
        float totalWidth = 0;
        float w = 0;
        foreach (Char c in chars)
        {
          w = pFont.GetWidth(c) / 1000;
          totalWidth += (w * curFontSize + this.UndercontentCharacterSpacing) * this.UndercontentHorizontalScaling / 100;
        }
        return totalWidth;
      }
      public override void RenderText(TextRenderInfo renderInfo)
      {
        LineSegment segment = renderInfo.GetBaseline();
        TextChunk location = new TextChunk(renderInfo.GetText(), segment.GetStartPoint(), segment.GetEndPoint(), renderInfo.GetSingleSpaceWidth());
        location.PosLeft = renderInfo.GetDescentLine().GetStartPoint()[Vector.I1];
        location.PosRight = renderInfo.GetAscentLine().GetEndPoint()[Vector.I1];
        location.PosBottom = renderInfo.GetDescentLine().GetStartPoint()[Vector.I2];
        location.PosTop = renderInfo.GetAscentLine().GetEndPoint()[Vector.I2];
        location.curFontSize = location.PosTop - segment.GetStartPoint()[Vector.I2];
        string StrKey = renderInfo.GetFont().PostscriptFontName + location.curFontSize.ToString();
        if (!ThisPdfDocFonts.ContainsKey(StrKey))
        {
          ThisPdfDocFonts.Add(StrKey, renderInfo.GetFont());
        }
        location.FontIndex = ThisPdfDocFonts.IndexOfKey(StrKey);
        locationalResult.Add(location);
      }
      private class TextChunk : IComparable<TextChunk>
      {
        public string text { get; set; }
        public Vector startLocation { get; set; }
        public Vector endLocation { get; set; }
        public Vector orientationVector { get; set; }
        public int orientationMagnitude { get; set; }
        public int distPerpendicular { get; set; }
        public float distParallelStart { get; set; }
        public float distParallelEnd { get; set; }
        public float charSpaceWidth { get; set; }
        public float PosLeft { get; set; }
        public float PosRight { get; set; }
        public float PosTop { get; set; }
        public float PosBottom { get; set; }
        public float curFontSize { get; set; }
        public int FontIndex { get; set; }
        public TextChunk(string str, Vector startLocation, Vector endLocation, float charSpaceWidth)
        {
          this.text = str;
          this.startLocation = startLocation;
          this.endLocation = endLocation;
          this.charSpaceWidth = charSpaceWidth;
          Vector oVector = endLocation.Subtract(startLocation);
          if (oVector.Length == 0)
          {
            oVector = new Vector(1, 0, 0);
          }
          orientationVector = oVector.Normalize();
          orientationMagnitude = (int)(Math.Truncate(Math.Atan2(orientationVector[Vector.I2], orientationVector[Vector.I1]) * 1000));
          Vector origin = new Vector(0, 0, 1);
          distPerpendicular = (int)((startLocation.Subtract(origin)).Cross(orientationVector)[Vector.I3]);
          distParallelStart = orientationVector.Dot(startLocation);
          distParallelEnd = orientationVector.Dot(endLocation);
        }
        public bool SameLine(TextChunk a)
        {
          if (orientationMagnitude != a.orientationMagnitude)
          {
            return false;
          }
          if (distPerpendicular != a.distPerpendicular)
          {
            return false;
          }
          return true;
        }
        public float DistanceFromEndOf(TextChunk other)
        {
          float distance = distParallelStart - other.distParallelEnd;
          return distance;
        }
        int IComparable<TextChunk>.CompareTo(TextChunk rhs)
        {
          if (this == rhs)
          {
            return 0;
          }
          int rslt;
          rslt = orientationMagnitude.CompareTo(rhs.orientationMagnitude);
          if (rslt != 0)
          {
            return rslt;
          }
          rslt = distPerpendicular.CompareTo(rhs.distPerpendicular);
          if (rslt != 0)
          {
            return rslt;
          }
          rslt = (distParallelStart < rhs.distParallelStart ? -1 : 1);
          return rslt;
        }
      }
    }
