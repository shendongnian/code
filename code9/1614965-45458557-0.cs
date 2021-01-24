    // Microsoft.Office.Interop.Word.Document document;
    foreach (TableOfContents tableOfContents in document.TablesOfContents)
    {
        tableOfContents.Update();
    }
    foreach (TableOfFigures tableOfFigures in document.TablesOfFigures)
    {
        tableOfFigures.Update();
    }
    foreach (Range storyRange in document.StoryRanges)
    {
        storyRange.Fields.Update();
    }
