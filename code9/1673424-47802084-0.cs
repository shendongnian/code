    public void replaceWordInFile(string fileName, string keyWord, string newWord) //Keyword sonrasındaki stringi verilen string ile değiştirir
        {
            StreamReader reading = File.OpenText(fileName);
            string pattern = @"\w+=([A-Za-z0-9\-_]+)";
            string str;
            while ((str = reading.ReadLine()) != null)
            {
                if (str.Contains(keyWord))
                {
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(str);
                    if (match.Success)
                    {
                        testLabel.Text = match.Groups[1].Value;
                    }
                }
            }
            reading.Close();
        }
