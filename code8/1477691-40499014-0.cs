       Dictionary<char, string> strDict = new Dictionary<char, string>();
            for (int i = 0; i < 26; i++)
            {
                if(!strDict.ContainsKey((char)(i+97)))
                {
                    strDict.Add((char)(i + 97), RandomString());
                }
                else
                {
                    strDict[(char)(i + 97)] = RandomString();
                }
            }
