       class MyDataGridView : KryptonDataGridView
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.Enter) && (this.EditingControl != null))
            {
                return true;
            }
            //for the rest of the keys, proceed as normal
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
