        public string ShowForm(out bool a)
        {
            ShowDialog();
            frm1.Enabled = true;
            if (folderSelected)
            {
                a = false;
                return selectedFolder;
            }
            else
            {
                a = true;
                return "";
            }
        }
