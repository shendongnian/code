    public class SomeClass
    {
        private frmMain someForm;
        public SomeClass(frmMain someForm)
        {
            this.frmMain = someForm;
            // Now you can do this
            var ctrl = this.frmMain.WhateverControlYouNeedToAccess;
            string controlText = ctrl.Text; //assuming it has Text property
        }
    }
