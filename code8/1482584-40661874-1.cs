            var totalWords = 0;
            using (StreamReader sr = new StreamReader("abc.txt"))
            {
    
                while (!sr.EndOfStream)
                {
                    int count = sr
                        .ReadLine()
                        .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Count();
                    totalWords += count;
                }
