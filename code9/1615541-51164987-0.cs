            var stream = new YamlStream();
            stream.Add(YamlDoc);
            string output;
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                stream.Save(writer, false);
                output = sb.ToString();
            }
            Console.WriteLine(output);
