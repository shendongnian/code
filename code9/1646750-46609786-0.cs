       if(string.IsNullOrWhiteSpace(lines[richTextBox1.Lines[i]]))
        {
        }
        else
        {
         
        }
       listView1.Items.Add(new ListViewItem(new[]{
            richTextBox1.Lines[i],
            richTextBox1.Lines[i+1], 
            richTextBox1.Lines[i+2]]}));
    }
