        Microsoft.Office.Interop.Word.Application WordObj;
        WordObj =
     (Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
        var word = (Word.Application)WordObj;
        string docPath=word.ActiveDocument.FullName;
