    private void btnOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.Title = "Open Word File";
        openFileDialog1.Filter = "Word Files (*doc)|*docx";   
    
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
    
            object fileName = openFileDialog1.FileName;
            // Define an object to pass to the API for missing parameters
            object missing = System.Type.Missing;
            doc = word.Documents.Open(ref fileName,ref missing, ref missing);
    
            String read = string.Empty;
            List<string> data = new List<string>();
            for (int i = 0; i < doc.Paragraphs.Count; i++)
            {
                string temp = doc.Paragraphs[i + 1].Range.Text.Trim();
                if (temp != string.Empty)
                data.Add(temp);
            }
            doc.Close();
            word.Quit();   
           foreach(var item in data)
    {
        txtTxt.Text += item;
    }
    
        } 
    }
