    ...
        string[] vlist = textBox1.Text.Split('\n');
        int size = (Convert.ToInt32(textBox2.Text)) / Convert.ToInt32(vlist) +1;
        string newString = ""
        for(int i=0;i<size;i++){
            newString = String.join('\n',vlist);
            textBox2.Text += newString
        }
    ...
