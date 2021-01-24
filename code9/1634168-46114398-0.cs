        OpenFileDialog fopen = new OpenFileDialog();
        fopen.Filter = "(All type)|*.*";
        fopen.ShowDialog();
        if(fopen.FileName != "")
        {
            textBox1.Text = fopen.FileName;
            string save = fopen.FileName;
            string save1 = save.Split('.')[0];
            //string readtext = File.ReadAllText(save);
            //string[] readtext1 = readtext.Split('\n');
            string[] readline = File.ReadAllLines(save);
            int lines = readline.Count();
            textBox2.Text = readtext;
            for (int i = 0; i < lines; i++ )
            {
                if (readline[i].Contains("CPL"))
                {                    
                    int len = readline[i].Length;
                    textBox3.Text += (readline[i].Substring(2, len - 4) + " ");
                }
            }
