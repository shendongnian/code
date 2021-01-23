    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
    {
    
     if ((myStream = saveFileDialog1.OpenFile()) != null)
        {
         using (var writer = new StreamWriter(myStream))
               {
                writer.Write("Information of Quote Number: ");
                writer.WriteLine(textbox1.Text);        
                writer.Write("Total Cost: ");
                writer.WriteLine(textbox2.Text);
                }
         }    
                myStream.Close();
    }
