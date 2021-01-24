        private void addCopy(string name, string clip)
        {
            string path = @"Files/User/c" + amount.ToString() + ".txt";
            StreamWriter w = new StreamWriter(path);
            w.WriteLine((name + "," + clip));
            w.Close();
        }
