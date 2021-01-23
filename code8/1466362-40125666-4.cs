     private void openTextToolStripMenuItem_Click(object sender, EventArgs e)
     {
         listBox1.Hide();
         // when building string in a loop use StringBuilder
         StringBuilder sb = new StringBuilder();  
         // do not close BinaryReader manually, put using instead 
         using (BinaryReader objBinReader = new BinaryReader(File.OpenRead(textBox3.Text)))
         {
             // PeekChar() is a method, notice () 
             while (objBinReader.PeekChar() != -1) 
                 sb.Append(objBinReader.ReadChar()); // ReadChar() is a method as well
         } 
         richTextBox1.Text = sb.ToString();
         richTextBox1.Show();
     }
