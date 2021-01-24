    using (StreamWriter sw = new StreamWriter(saveFile1.FileName, true))
       {
          string text = "";
          foreach (var item in listBox1.Items)
           {
             text += item.ToString() + Environment.NewLine; //I added new line per list.
           }
        sw.WriteLine(text);
        sw.Close();
       }
