    Microsoft.Office.Interop.Word.Application WordObj;
    WordObj = (Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    for (int i = 0; i < WordObj.Windows.Count; i++)
    {
        object idx = i + 1;
        Window WinObj = WordObj.Windows.get_Item(ref idx);
        doc_list.Add(WinObj.Document.FullName);
    }
