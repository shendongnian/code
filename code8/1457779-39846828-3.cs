        public void MyClose(IRibbonControl control, bool cancelDefault)
        {
            Application.ActiveDocument.Close(WdSaveOptions.wdPromptToSaveChanges);
        }
   
