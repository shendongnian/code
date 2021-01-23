            using(var file = new StreamWriter(File.Open(Directory + Output1, FileMode.Create), Encoding.GetEncoding(1257)))
            {
                //your loop
            }
    
            for (int i = 0; i < people.Count; i++)
            {
                using(file = new StreamWriter(File.Open(path, FileMode.Create), Encoding.GetEncoding(1257)))
                {
                     // other loop
                }
            }
