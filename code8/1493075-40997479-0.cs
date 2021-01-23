        using (StreamWriter writer = new StreamWriter(fvr))
        {
            string[] lines = File.ReadAllLines(fv,Encoding.GetEncoding(1257));
            foreach (string line in lines)
            {
                var words = line.Split(skyrikliai2, StringSplitOptions.RemoveEmptyEntries);
                var outputLine = string.Join(" ", words);
                writer.WriteLine(outputLine);
            }
        }
