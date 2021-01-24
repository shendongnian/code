    using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if(dialog.ShowDialog(this) == DialogResult.OK)
                {
                    List<string> result = new List<string>();
                    string[] lines = System.IO.File.ReadAllLines(dialog.FileName);
                    foreach (var line in lines)
                    {
                        var splittedValues = line.Split(',');
                        result.Add(splittedValues[0]);
                    }
                }
            }
