            while (filename != null)
            {
                textBox1.Text += filename;
                filename = fileReader.ReadLine();
            }
        }
        //textBox1.Text = filename;
        spam.ScanMessage(textBox1.Text);
