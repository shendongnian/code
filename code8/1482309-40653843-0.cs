        string line = null;
        while(line = sr.ReadLine() != null)
            sw. WriteLine(line. Replace("'",  "")) ;
    } 
    System.IO.File.Delete("file01.txt");
    System.IO.File.Move("file02.txt",  "file 01.txt ");
