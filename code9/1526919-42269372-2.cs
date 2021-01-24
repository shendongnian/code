            private Microsoft.Office.Interop.Word.ContentControl rt = null;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.ActiveDocument.ContentControlOnEnter += ActiveDocument_ContentControlOnEnter;
        }
        private void ActiveDocument_ContentControlOnEnter(Word.ContentControl cc)
        {
            cc.Type = Word.WdContentControlType.wdContentControlRichText;
            this.rt = cc;
			
			
        }
