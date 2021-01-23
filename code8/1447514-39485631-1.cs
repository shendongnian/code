        string[] test(string path)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(path);
            string[] str = sr.ReadToEnd().Split(';');
            sr.Close();
            return str;
        }
