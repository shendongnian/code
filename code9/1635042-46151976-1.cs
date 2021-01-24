      while (listBox1.SelectedItems.Count > 0)
      {
        var index = listBox1.Items.IndexOf(listBox1.SelectedItem);
        listBox1.Items.RemoveAt(index);
        RemoveTextLine(index);
      }
    private void RemoveTextLine(int index){
    
      using(var sr = new StreamReader("C:\Users\StanleyM\Desktop\PhoneBook\PhoneBook\bin\Debug\Personal.text"))
      using(var sw = new StreamWriter("C:\Users\StanleyM\Desktop\PhoneBook\PhoneBook\bin\Debug\temp.text"))
      {
       int line=0;
       while((sr.ReadLine()) != null)
       {
          if(line != index)
          sw.WriteLine(line);
          line ++;
       }
     }
    
      File.Delete("Personal.txt");
      File.Move(tempFile, "Personal.txt");
    }
