    using (var output_file = File.CreateText("outputFile.txt"))
    {
        foreach (var line in File.ReadLines("inputFile.txt"))
        {
            int start = 0;
            while (start < line.Length)
            {
                // look for start of word
                while (start < line.Length && line[start] == ' ')
                {
                    ++start;
                }
                if (start >= line.Length)
                {
                    // no more words on line
                    break;
                }
                // now look for end of word
                int end = start+1;
                while (end < line.Length && line[end] != ' ')
                {
                    ++end;
                }
                int length = end - start;
                if ((length % 2) == 0)
                {
                    output_file.WriteLine(line.Substring(start, length));
                }
                // reposition start for next word
                start = end;
            }
        }
    }
