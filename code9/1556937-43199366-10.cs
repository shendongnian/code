    using (OpenFileDialog dialog = new OpenFileDialog())
    {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            string sFileName = dialog.FileName;
            pathFolder2 = sFileName;
            label3.Text = pathFolder2;
            label3.Show();
            string[] lines = System.IO.File.ReadAllLines(dialog.FileName);
            int i = 0;
            foreach (var line in lines)
            {
                var splittedValues = line.Split(',');
                var firstWord = splittedValues[0];
                if (i == 0)
                {
                    resultStation2 = firstWord;
                }
                else
                {
                    if (resultStation2 != firstWord)
                    {
                        MessageBox.Show("Файла трябва да съдържа само една станция!");
                        return;
                    }
                }
                
                i++;
            }
        }
    }
