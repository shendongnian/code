            List<string> myListOfNames = new List<string>();
            int totalnames = 10;
            for (int i = 0; i < totalnames; i++)
            {
                myListOfNames.Add("name" + i);
            }
            using (StreamWriter writer =  new StreamWriter("C:\\MyTextFile.txt", true))
            {
                foreach (string name in myListOfNames)
                {
                    writer.WriteLine(name);
                }
            }
