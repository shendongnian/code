    public class CustomDGV : DataGridView
    {
        public event EventHandler EnterKeyPressed;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                RaiseEnterKeyPressedEvent();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void RaiseEnterKeyPressedEvent()
        {
            if (EnterKeyPressed != null)
                EnterKeyPressed(this, EventArgs.Empty);
        }
    }
