        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //Uncheck the checkedListBox items only once.
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            s = listBox2.SelectedItem.ToString();
            //Remove all the NewLines added by StringBuilder.AppendLine
            s = s.Replace(Environment.NewLine, "");
            //Split and ensure no empty elements
            string[] tokens = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //Loop through tokens
            for (int y = 0; y < tokens.Length; y++)
            {
                //Add token to listBox1
                listBox1.Items.Add(tokens[y]);
                //loop through checkedListBox1.Items for each token
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.Items[i].ToString() == tokens[y])
                    {
                        //Check only if they match! 
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
        }
