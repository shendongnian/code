        public static void WriteAllLines(string path, IEnumerable<string> contents)
        {
            using (var s = new FileStream(path, FileMode.Append))
            {
                foreach (var line in contents)
                {
                    var bytes = Encoding.ASCII.GetBytes($"{line}\r");
                    s.Write(bytes,0,bytes.Length);
                }
                s.Flush();
                s.Close();
            }
        }
