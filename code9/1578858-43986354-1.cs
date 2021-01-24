    using Microsoft.Office.Interop.Word;
    
    ...
    
    public void SubmitPassword(string password)
    {
        Application app = new Application();
        app.Documents.Open(FileName: "filename.docx", PasswordDocument: password);
    }
