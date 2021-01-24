    Microsoft.Office.Interop.Word.Application v_appAC = new Microsoft.Office.Interop.Word.Application();
    Microsoft.Office.Interop.Word.Document v_doc;
    v_doc = v_appAC.Documents.Open(p_strPath);
    v_appAC.Visible = true;
    v_appAC.PrintPreview = true;
    v_doc.Close();
    v_appAC.Quit();
