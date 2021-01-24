    using (StringReader reader = new StringReader(_input))
            {
                // Loop over the lines in the string.
                int numberOfSearchedValue= 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if(line.Split(';')[1] == "111")
                    numberOfSearchedValue++;
                }
            }
