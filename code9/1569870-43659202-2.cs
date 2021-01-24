            var sb = new StringBuilder();
            using (TextWriter writer = new Utf8StringWriter(sb))
            {
                xdoc.Save(writer);
            }
            var xmlString = sb.ToString();
