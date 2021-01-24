        private void UnlockVnosAgains()
        {
            //here we have a Dictionary of all the tags you want to handle.
            //True for boxes which should be readonly, false for boxes which should not be.
            Dictionary<string, bool> mytags = new Dictionary<string, bool>();
            mytags.Add("SomeTag1", false);//leave it alone
            mytags.Add("SomeTag2", true);//make it readonly
            mytags.Add("SomeTag3", true);//make it readonly
            mytags.Add("SomeTag4", false);//leave it alone
            mytags.Add("DoNotUnlock", true);//make it readonly
            foreach (Control c in this.Controls)
            {
                //if C is a textbox, and the Tag is NOT null and the dictionary contains the tag
                if ((c is TextBox && c.Tag != null && mytags.Keys.Contains((string)c.Tag)))
                {
                    ((TextBox)c).ReadOnly = mytags[(string)c.Tag];//assign the appropriate bool from the dictionary
                    ((TextBox)c).BackColor = Color.FromArgb(255, 255, 192);//do your color thing... wink wink, this one could be stored along with your true or false too
                }
            }
        }
