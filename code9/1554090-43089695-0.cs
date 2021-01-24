    List<string> lines = File.ReadLines(path, Encoding.Default).ToList();
    string dataSource = lines[0].Replace("DataSource = ", "");
    string database = lines[1].Replace("DataBase = ", "");
    string userName = lines[2].Replace("UserName = ", "");
    string password = lines[3].Replace("PassWord = ", "");
