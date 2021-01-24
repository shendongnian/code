        public string GetResourceTextFile(string filename)
        {
            string result = string.Empty;
            //  In the code below, replace xyz. with the name of your dll + .
            // (dot). Idea is to treat file like dllName.filename.xml
            using (Stream stream = this.GetType().Assembly.
                       GetManifestResourceStream("xyz." + filename))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }
