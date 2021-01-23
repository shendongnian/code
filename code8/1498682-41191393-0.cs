    using (StreamReader sr = File.OpenText(source)
    using (StreamWriter sw1 = File.AppendText(path1))
    using (StreamWriter sw2 = File.AppendText(path2))
    using (StreamWriter sw3 = File.AppendText(path3))
    using (StreamWriter sw4 = File.AppendText(path4))
    using (StreamWriter sw5 = File.AppendText(path5))
    using (StreamWriter sw6 = File.AppendText(path6))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            if(line.StartsWith("Report 1")
            {
                sw1.WriteLine(line);
            }
            else if(line.StartsWith("Report 2")
            {
                sw2.WriteLine(line);
            }
            else if(line.StartsWith("Report 3")
            {
                sw3.WriteLine(line);
            }
            else if(line.StartsWith("Report 4")
            {
                sw4.WriteLine(line);
            }
            else if(line.StartsWith("Report 5")
            {
                sw5.WriteLine(line);
            }
            else if(line.StartsWith("Report 6")
            {
                sw6.WriteLine(line);
            }
            else
            {
                throw new InvalidDataException($"Line does not start with a report number: \n{line}");
            }
        }
    }
