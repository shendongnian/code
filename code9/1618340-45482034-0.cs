    if(File.Exists(@pathTextBox.Text)
    {
      using(Stream st = File.Open(pathTextBox.Text, FileMode.Open))
       {
        st.Seek(0x12, SeekOrigin.Begin);
        st.WriteByte(0x00);
       }
    }
