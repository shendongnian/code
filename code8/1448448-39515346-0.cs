                var builder = new StringBuilder();
                for (int i = 0; i < 99999; i++)
                {
                    builder.Append(i.ToString() + '\n');
                }
    
                File.WriteAllText("asd.txt", builder.ToString());
