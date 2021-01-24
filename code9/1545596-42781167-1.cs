    for(int i=0; i < lines.Length; i++)
    {
        if(i == lines.Length - 1)
        {
            file.Write(line);
        }
        else 
        {
            file.WriteLine(line);
        }
    }
