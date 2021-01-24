    using(FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
    {
    	if (fs.CanWrite)
            {
            	string columnTitles = "name,age,sex\n";
                fs.Write(Encoding.ASCII.GetBytes(columnTitles), 0, 0);
                string input = name + "," + age + "," + sex + "\n";
                fs.Write(Encoding.ASCII.GetBytes(input), 0, ASCIIEncoding.ASCII.GetByteCount(input));
            }
    }
