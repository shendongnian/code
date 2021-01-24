    public static class Extensions
    {
        public static string ReadTextResource(this Assembly asm, string resName)
        {
            string text;
            using (Stream strm = asm.GetManifestResourceStream(resName))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    text = sr.ReadToEnd();
                }
            }
            return text;
        }
    }
