        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listSearch.RunWorkerAsync(textBox1.Text);
        }
        private void ListSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            string text = e.Argument as string;
            List<string> items = new List<string>();
            foreach (string item in tempList)
            {
                if (item.ToLower().Contains(text.ToLower()))
                {
                    items.Add(item);
                }
            }
            e.Result = items.ToArray();
        }
       private void ListSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] items = e.Result as string[];
            Invoke((Action)(() =>
            {
                listBox1.Items.Clear();
                foreach(string item in items)
                {
                    listBox1.Items.Add(item);
                }
            }));
        }
