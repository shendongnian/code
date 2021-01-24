    protected void btnRead_Click(object sender, EventArgs e)
    {
        string text = String.Empty;
        int i = 0;
        int countedChars;
        using (StreamReader stRead = new StreamReader(FileUpload1.PostedFile.InputStream))
        {
            //to write textfile content         
            while (!stRead.EndOfStream)
            {
                //ListBox1.Items.Add(stRead.ReadLine());
                text += stRead.ReadLine() + Environment.NewLine;
                MatchCollection collection = Regex.Matches(stRead.ReadLine(), @"[D;]+");
                countedChars= collection.Count;
                i++;
            }
         }
        TextBox1.Text = text;
        //Label1.Text = i.ToString();
        Label1.Text =  this.TextBox1.Text.Split(new Char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
        //populateListBox();
    }
