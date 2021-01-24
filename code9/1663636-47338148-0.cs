            using (FileStream fs = new FileStream("Test.txt", FileMode.Append, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("test");
                }
            }
