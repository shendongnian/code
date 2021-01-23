    using Microsoft.Office.Interop.Word;
        void ItemEvents_BeforeAttachmentAdd(Outlook.Attachment attachment, ref bool Cancel)
        {
             if (attachment.Type == Outlook.OlAttachmentType.olByValue)
            {
                string url = "A URL";
                 Document doc = currentMailItem.GetInspector.WordEditor;
                Selection objSel = doc.Windows[1].Selection;
                object missObj = Type.Missing;
                doc.Hyperlinks.Add(objSel.Range, url, missObj, missObj, attachment.DisplayName, missObj);
                Cancel = true;
            }
        }
