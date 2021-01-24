        public string ShowForm(out bool a)
        {
            ShowDialog();
            frm1.Enabled = true;
            if (!Directory.Exists(selectedFolder))
            {
                a = true;
                return selectedFolder;
            }
            else
            {
                a = false;
                return selectedFolder;
            }
        }
