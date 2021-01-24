    AcroPDDoc() pdfDoc = new AcroPDDoc();
    if (pdfDoc.Open(sourceFileName))
    {
        Object jsObj = pdfDoc.GetJSObject();
        Type type = jsObj.GetType();
        object[] saveAsParam = { convertedFilePath, "com.adobe.acrobat.docx" };
        type.InvokeMember(
            "saveAs",
            BindingFlags.InvokeMethod |
            BindingFlags.Public |
            BindingFlags.Instance,
            null, jsObj, saveAsParam);
    }
