    internal class WinFormsWrapper
    {
        private Form _form;
        public WinFormsWrapper(Form f)
        {
            _form = f;            
        }
        public void Run()
        {
            //Winforms exceptions thrown on the message loop should go here
            //this handler will force them do be "rethrown" on the calling dispatcher
            System.Windows.Forms.Application.ThreadException += (wf_sender, wf_e) => { ExceptionDispatchInfo.Capture(wf_e.Exception).Throw(); };
            System.Windows.Forms.Application.Run(_form);
        }
    }
