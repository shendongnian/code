        protected void Button1_Click(object sender, EventArgs e)
        {
            string valueString = HiddenField1.Value;
            if (!string.IsNullOrEmpty(valueString))
            {
                string [] valueArray = valueString.TrimEnd(',').Split(',');
                foreach (string s in valueArray)
                {
                    //do stuff
                }
            }
        }
