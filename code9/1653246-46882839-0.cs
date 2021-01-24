    Random rnd = new Random();
    List<long> generatedNumbers = new List<long>();
    for (int i = 0; i < numberoffiles; i++)
    {
        long rndsize = rnd.Next(1, 2000);
        if(generatedNumbers.Contains(rndSize)) 
        {
          i--;
          continue;
        }
    
        generatedNumbers.Add(rndSize);
        FileStream fs = new FileStream(@"c:\temp\files\huge_dummy_file" + i, FileMode.CreateNew);
        fs.Seek(rndsize * 1024, SeekOrigin.Begin);
        fs.WriteByte(0);
        fs.Close();
    }
