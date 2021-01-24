        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    // Close the dialog
                    Close();
                    return true;
                case Keys.Control | Keys.Enter:
                    // Perform the primary action
                    ActionMerge();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
