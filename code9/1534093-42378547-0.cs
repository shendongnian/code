    string s = textBox1.Text.ToString();
            string[] values = s.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim();
            }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);//First uncheck the old value!
                                                         //
                for (int x = 0; x < values.Length; x++)
                {
                    if (checkedListBox1.Items[i].ToString() == values[x].ToString())
                    {
                        //Check only if they match! 
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
