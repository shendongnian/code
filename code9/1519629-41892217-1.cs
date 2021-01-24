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
                var readedLine = stRead.ReadLine() 
                //ListBox1.Items.Add(readedLine );
                text += readedLine  + Environment.NewLine;
                
                if(!string.IsNullOrWhiteSpace(readedLine))
                {
                    MatchCollection collection = Regex.Matches(readedLine, @"[D;]+");
                   countedChars= collection.Count;
                }
                i++;
            }
         }
        TextBox1.Text = text;
        //Label1.Text = i.ToString();
        Label1.Text =  this.TextBox1.Text.Split(new Char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
        //populateListBox();
    }
