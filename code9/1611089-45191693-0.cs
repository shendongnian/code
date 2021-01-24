     public bool useUnkownEntity(string strTest)
            {
                Regex rgx = new Regex("[^a-zA-Z/s/ ]");
                List<string> unkown = new List<string> { "Unkown", "tba", "tbc","N/A"};
                  strTest = rgx.Replace(strTest, "");
                if (unkown.Contains(strTest, StringComparer.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Please refer to the unkown Entity within!!");
                    return false;
                }
                return true;
                
            }
