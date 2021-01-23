    Private Shared Sub SetupParagraphsTemplates(Application As Microsoft.Office.Interop.Word.Application)
        ParagraphTemplate = Application.ListGalleries(Microsoft.Office.Interop.Word.WdListGalleryType.wdOutlineNumberGallery).ListTemplates(2)
        ParagraphTemplate.ListLevels(1).NumberStyle = Microsoft.Office.Interop.Word.WdListNumberStyle.wdListNumberStyleArabic
        ParagraphTemplate.ListLevels(2).NumberFormat = "%2."
        ParagraphTemplate.ListLevels(2).NumberStyle = Microsoft.Office.Interop.Word.WdListNumberStyle.wdListNumberStyleLowercaseLetter
        ParagraphTemplate.ListLevels(3).NumberStyle = Microsoft.Office.Interop.Word.WdListNumberStyle.wdListNumberStyleArabic
        ParagraphTemplate.ListLevels(3).NumberFormat = "%3."
    End Sub
