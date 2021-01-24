    string[] lines = File.ReadAllLines("E:\\SAMPLE_FILE\\sample.txt");         
    var tolist = lines.Where(x => (x.ToUpper().Trim() == textBox1.Text.ToUpper().Trim())).FirstOrDefault();
    if (tolist != null)
     {
          MessageBox.Show("Record found.");
     }
     else
     {
         MessageBox.Show("Record not found.");
     }
