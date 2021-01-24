        protected void BtnGetValues_Click(object sender, EventArgs e)
        {
            IList<string> valueReturnArray = new List<string>();
            foreach (Control d in divToAddTo.Controls)
            {
                if (d is TextBox)
                {
                    valueReturnArray.Add(((TextBox)d).Text);
                }
            }
            //valueReturnArray will now contain the values of all the textboxes
        }
