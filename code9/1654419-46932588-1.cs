    public string GenerateBase64(string FileName)
        {
            byte[] b = System.IO.File.ReadAllBytes(FileName);
            string s = Convert.ToBase64String(b);
            return s;
        }
