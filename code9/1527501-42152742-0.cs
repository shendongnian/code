    private void button8_Click(object sender, EventArgs e)
            {
                ArrayList list = new ArrayList();
                foreach (object item in checkedListBox1.CheckedItems)
                {
                    list.Add(item.ToString());
                }
            }
