            Dictionary<string, int> values = new Dictionary<string, int>();
            string textBoxString = textBoxName.Text;
            
            // Splits text into array of seperate lines
            List<string> split = s.Split(Environment.NewLine.ToCharArray()).ToList();
            for (int i = 0; i < split.Count; i++)
            {
                // removes free spaces
                split[i] = split[i].Replace(" ", String.Empty);
                // splits one line into pair of property name (example: temperature) and it's value after seperator ":"
                string[] keyPair = split[i].Split(':'); 
                // adds property name as dictionary's key and value as dictionary's value
                values.Add(keyPair[0], int.Parse(keyPair[1])); 
            }
