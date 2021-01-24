       using Word = Microsoft.Office.Interop.Word;
       ...
       public void submitPassword()
       {
            var wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Open(FileName: @"filepath", PasswordDocument: "filepassword");
       }
