            using (var stream = File.OpenRead(fileSaveLocation))
            using (var reader = new StreamReader(stream))
            {
                var data = CsvParser.ParseHeadAndTail(reader, ',', '"');
                var header2 = data.Item1;
                var lines = data.Item2;
                for (int i = 4; i < header2.Count; i++)
                    sb.Append(("\"" + header2[i] + "\"" + ","));
                sb.Append(sb.ToString().TrimEnd(','));
                sb.Append(Environment.NewLine);
                foreach (var line in lines)
                {
                    for (var i = 4; i < header2.Count; i++)
                    {
                            sb.Append("\"" + line[i] + "\"");
                        if (i != header2.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append(Environment.NewLine);
                }
            }
