    private void Form1_Load(object sender, EventArgs e)
    {
      Assembly asm = Assembly.GetExecutingAssembly();
      Stream s = asm.GetManifestResourceStream("ExcelAsResource.Resources.TestEmbeddedExcel.xlsx");
      FileStream fs = new FileStream(@"C:\Users\John\Desktop\cs\TestCopy.xlsx", FileMode.OpenOrCreate);
      s.CopyTo(fs);
      fs.Close();
      s.Close();
    }
