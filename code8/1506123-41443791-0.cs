            while ((line = reader.ReadLine()) != null)
            {
                string[] tokens = line.Split(new char[] { ' ', '\t', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string line;
                if (tokens[1].Equals(ColChangable1) || tokens[1].Equals(ColChangable2))
                {
                    line =tokens[0] + "\t" + "\"TRIM(:" + tokens[0] + ")";
                }
                else if (tokens[1].Equals(ColChangable3))
                {
                    line = tokens[0] + "\t";
                }
                else if (tokens[1].Equals(ColChangable4))
                {
                    line = tokens[0] + "\t" + "DATE";
                }
                if (reader.EndOfStream)
                {
                    line = line + ".";
                }
                else
                {
                    line = line + ",";
                }
                sw.WriteLine(line);
            }
