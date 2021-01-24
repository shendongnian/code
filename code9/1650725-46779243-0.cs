            var embeddedResource = "<namespace>.EmailTemplate.html";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedResource))
            {
                StreamReader sr = new StreamReader(stream);
                body = sr.ReadToEnd();
            }
