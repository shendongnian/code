    using Office = Microsoft.Office.Core;
    using Microsoft.Office.Tools.Word;
    using System.Text.RegularExpressions;
    using Word = Microsoft.Office.Interop.Word;
    //declare and get the current document 
    Document extendedDocument = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);
    List<string> bookmarksProcessed = new List<string>();  
  
    foreach(Word.Bookmark oldBookmark in extendedDocument.Bookmarks)
    {
        if(bookmarksProcessed.Contains(oldBookmark.Name))
        {
            string newText = getTextFromBookmarkName(oldBookmark.Name)
            Word.Range newRange = oldBookmark.Range;
            newRange.End = newText.Length;
            Word.Bookmark newBookmark = extendedDocument.Controls.AddBookmark(newRange, oldBookmark.Name);
        
            newBookmark.Text = newText;
        }
    }
