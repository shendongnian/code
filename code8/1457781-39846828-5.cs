        public void MyClose(IRibbonControl control, bool cancelDefault)
        {
            var doc = Application.ActiveDocument;
            doc.Close(WdSaveOptions.wdPromptToSaveChanges);
            // check whether the document is still open
            var isStillOpen = Application.IsObjectValid[doc];
        }
   
