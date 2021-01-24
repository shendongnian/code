      using (StreamReader file = new StreamReader(openFileDialog1.FileName)) {
        while (!file.EndOfStream) {
          string color = file.ReadLine();
          string name = file.ReadLine();
          string number = file.ReadLine();
          if (color == "blue") {
            listBox1.Items.Add(name);
            listBox2.Items.Add(number);
          }
          else if (color == "red") {
            listBox3.Items.Add(name);
            listBox4.Items.Add(number);
          }
        }  
      }
