     try
        {
            foreach (DirectoryInfo dir in diArr)
            {
                if (dir.LastWriteTime < DateTime.Parse(daysPast))
                    Directory.Delete(dir.FullName, true);
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine("File(s) deleted on: " + DateTime.Now);
                    sw.WriteLine("============================================");
                    sw.WriteLine("");
                    sw.WriteLine(dir);
                    sw.WriteLine("");
                    sw.WriteLine("End of list");
                    sw.WriteLine("");
                    sw.Flush();
                }
            }
        }
