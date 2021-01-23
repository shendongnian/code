       if (result == DialogResult.OK)
                {
        
                    string filename = fileChooser.FileName;
        
                    //result = fileChooser.ShowDialog();
                    StreamReader fileReader = new StreamReader(filename);
        
                    while (filename != null)
                    {
                        textBox1.Text += filename;
                        filename = fileReader.ReadLine(); // <-- THIS IS THE PROBLEM
                    }
                }
