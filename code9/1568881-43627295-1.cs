            string line;
            var result = new StringBuilder();
            using (var reader = new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.EndsWith(myWord))
                        result.AppendLine(line);
                }
            }
            outputEmails.Text = result.ToString();
