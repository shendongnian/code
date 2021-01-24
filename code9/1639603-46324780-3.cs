    class SomeControl : UserControl
    {
        Form _owner;
        public SomeControl()
        {
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            _owner = FindForm();
            _owner.FormClosing += _owner_FormClosing;
            _owner.FormClosed += _owner_FormClosed;
        }
        private void _owner_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void _owner_FormClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
