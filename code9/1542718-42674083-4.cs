        private void UnlockVnos()
        {
            Dictionary<string, bool> mytags = new Dictionary<string, bool>();
            mytags.Add("DoNotUnlock", false);
            mytags.Add("StayAwayFromThisBox", false);
            mytags.Add("DontEvenDateUnlockThis", false);
            foreach (Control c in this.Controls)
            {
                if ((c is TextBox && c.Tag == null || !mytags.Keys.Contains((string)c.Tag)))
                {
                    ((TextBox)c).ReadOnly = false;
                    ((TextBox)c).BackColor = Color.FromArgb(255, 255, 192);
                }
            }
        }
