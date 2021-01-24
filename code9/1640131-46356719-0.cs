    using System;
    using System.Collections.Generic;
    using System.IO;
    using Apitron.PDF.Kit.FixedLayout;
    using Apitron.PDF.Kit.FixedLayout.Content;
    using Apitron.PDF.Kit.FixedLayout.PageProperties;
    using Apitron.PDF.Kit.Interactive.Annotations;
    using Apitron.PDF.Kit.Interactive.Forms;
    
        public void TestAcroForm_TextBlock()
        {
            using (Stream stream = new FileStream("filename.pdf", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (FixedDocument document = new FixedDocument())
                {
                    Page page = document.Pages[0];
                    TextField textField = new TextField("UserName", "This is user name");
                    TextFieldView annotation = new TextFieldView(textField, new Boundary(100, 100, 300, 130));
                    document.AcroForm.Fields.Add(textField);
                    page.Annotations.Add(annotation);
                    using (Stream outStream = new FileStream("filename_out.pdf", FileMode.Create, FileAccess.ReadWrite))
                    {
                        document.Save(outStream);
                    }
                }
            }
        }
