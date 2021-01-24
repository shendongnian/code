            Object oMissing = System.Reflection.Missing.Value;
            Object oTrue = true;
            Object oFalse = false;
            Application oWord = new Application();
            Document oWordDoc = new Document();
          //  oWord.Visible = true;
            Object oTemplatePath = @"C:\Users\ISAAC B\Desktop\TECH HAVEN PROJECTS\Arup\template.docx";
            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
            foreach (Field myMergeField in oWordDoc.Fields)
            {
                Range rngFieldCode = myMergeField.Code;
                String fieldText = rngFieldCode.Text;
                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    Int32 endMerge = fieldText.IndexOf("\\", StringComparison.Ordinal);
                    Int32 fieldNameLength = fieldText.Length - endMerge;
                    String fieldName = fieldText.Substring(11, endMerge - 11);
                    fieldName = fieldName.Trim();
                    if (fieldName == "Name")
                    {
                        myMergeField.Select();
                        oWord.Selection.TypeText("Tayo Isaac Bakare");
                    }
                }
            }
            oWordDoc.SaveAs(@"C:\Users\ISAAC B\Desktop\TECH HAVEN PROJECTS\Arup\Project2017.docx");
            oWordDoc.Close();
            oWord.Quit();
