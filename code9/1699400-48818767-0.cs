            var binary = GetBinaryFileFromDatabase();
            var inputLines = Encoding.Default.GetString(binary).Split('\n');
            var outputLines = new List<string>();
            
            foreach (var line in inputLines)
            {
                var columns = line.Split(';');
                if (columns.Length > 28 && columns[28] != null && columns[28].Length > 0)
                {
                    columns[28] = columns[28].Replace(Path.GetFileName(columns[28]), "SomeValue");
                }
                outputLines.Add(string.Join(";", columns));
            }
            File.WriteAllLines(outputPath, outputLines);
