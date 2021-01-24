    public static string GetIndentionTextFromParagraph(this Paragraph paragraph)
    {
        int numberingId = paragraph.ParagraphProperties.NumberingProperties.NumberingId.Val; 
        int numberingLevel = paragraph.ParagraphProperties.NumberingProperties.NumberingLevelReference.Val;
        //isolate paragraphs with the correct numbering id and indention level
        var paragraphsInList = paragraph.Parent.Descendants<Paragraph>().Where(p =>
    		p.ParagraphProperties != null &&
    		p.ParagraphProperties.NumberingProperties != null &&
    		p.ParagraphProperties.NumberingProperties.NumberingId.Val == numberingId &&
    		p.ParagraphProperties.NumberingProperties.NumberingLevelReference.Val == numberingLevel
    		).ToList();
        //find position of paragraph in list
        int paragraphPositionInLevelOfList = paragraphsInList.IndexOf(paragraph);
        //boil the level down to always being between 0 and 2 so we can chose what kind of response we want to give
        while (numberingLevel > 2)
        {
    		numberingLevel = numberingLevel - 3;
        }
    
        if (numberingLevel == 0)
        {
    		//return a number
    		return (paragraphPositionInLevelOfList + 1).ToString();
        }
        else if (numberingLevel == 1)
        {
    		//return a letter
    		return "abcdefghijklmnopqrstuvwxyz"[paragraphPositionInLevelOfList].ToString();
        }
        else if (numberingLevel == 2)
        {
    		//return roman
    		return ToRoman(paragraphPositionInLevelOfList + 1);
        }
        else return "unknown list configuration";
    }
