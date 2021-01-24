    FormEditor f2 = new FormEditor();
    using (System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName))
    {
         f2.richTextBox1.Text = sr.ReadToEnd();
    }
    f2.ShowDialog();
