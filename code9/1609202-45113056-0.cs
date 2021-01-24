    string DatabaseFullPath = @"C:\Test2.xsr";
    using (var file = new StreamReader(DatabaseFullPath, Encoding.UTF8)) {
        using (StreamWriter writetext = new StreamWriter(@"D:\Test.txt")) {
            int count = 0;
            string line;
            while ((line = file.ReadLine()) != null) {
                if (++count % 3 == 0)
                    writetext.WriteLine(line);
                else
                    writetext.Write(line + ',');
            }
        }
    }
