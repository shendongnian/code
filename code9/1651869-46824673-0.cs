            public int countf = 0;
            public void AddFiles(string[] files, int startIndex, int count, Label textLabel)
            {
                while (count-- > 0)
                {
                    countf++;
                    listBox.Items.Add(files[startIndex + count]);
                    textLabel.Text = "";
                }
            }
