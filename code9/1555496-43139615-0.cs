       private void button1_Click(object sender, EventArgs e)
        {
            Object oMissing = System.Reflection.Missing.Value;
            Object oTemplatePath = "D:\\template.dotx";
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document wordDoc = new Document();
            wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
            foreach (Field myMergeField in wordDoc.Fields)
            {
                Range rngFieldCode = myMergeField.Code;
                String fieldText = rngFieldCode.Text;
                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    Int32 endMerge = fieldText.IndexOf("\\");
                    Int32 fieldNameLength = fieldText.Length - endMerge;
                    String fieldName = fieldText.Substring(11, endMerge - 11);
                    fieldName = fieldName.Trim();
                    if (fieldName == "lbl_name")
                    {
                        myMergeField.Select();
                        wordApp.Selection.TypeText("my data");
                    }
                }
            }
            wordDoc.SaveAs("D:\\myfile.doc");
            wordDoc.SaveAs2("D:\\myfile.pdf", WdSaveFormat.wdFormatPDF);
            wordDoc.Close();
            wordApp.Application.Quit();
        }
