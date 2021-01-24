    using (System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName))
    {
        FormEditor f2 = new FormEditor(sr.ReadToEnd());
        f2.ShowDialog();
    }
