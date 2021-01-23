     string strSerial = @"Microsoft";
                Regex match = new Regex(strSerial);
                string matchinglines = string.Empty;
                List<string> filenames = new List<string>(Directory.GetFiles(textBox1.Text));
                foreach(string filename in filenames)
                {
                    //StreamReader strFile = new StreamReader(filename);
                    string fileContent = File.ReadAllText(filename);
                    if(match.IsMatch(fileContent))
                    {
                        label1.Text = Regex.Match(fileContent, strSerial).ToString();
                        break;
                    }
                }
