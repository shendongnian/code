    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
         try{
            var result = saveFileDialog1.FileName ?? throw new System.IO.IOException("No FileName selected?!");
            writer = new StreamWriter(result);            
            writer.WriteLine(header);
            writer.WriteLine(LineOneData);
            writer.Close();
            }
          catch (System.IO.IOException exp)
            {
              DoSomethingWithThe(exp);
            } 
           finally
            {
              if (writer != null)
                {
                    writer.Close();
                }           
            }
        }
